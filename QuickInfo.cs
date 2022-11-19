using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;

namespace CourseWork
{
    internal class QuickInfoSource : IQuickInfoSource
    {
        private QuickInfoSourceProvider m_provider;
        private ITextBuffer m_subjectBuffer;
        private ITextSearchService m_textSearchService;
        //private List<List<string>> variableTypes;


        public QuickInfoSource(QuickInfoSourceProvider provider, ITextBuffer subjectBuffer, ITextSearchService textSearchService)
        {
            m_provider = provider;
            m_subjectBuffer = subjectBuffer;
            m_textSearchService = textSearchService;
            //variableTypes = new List<List<string>>();
            //variableTypes = SettingsLoader.getSpecs();
        }

        public void AugmentQuickInfoSession(IQuickInfoSession session, IList<object> qiContent, out ITrackingSpan applicableToSpan)
        {
            // Map the trigger point down to our buffer.
            SnapshotPoint? subjectTriggerPoint = session.GetTriggerPoint(m_subjectBuffer.CurrentSnapshot);
            if (!subjectTriggerPoint.HasValue)
            {
                applicableToSpan = null;
                return;
            }

            ITextSnapshot currentSnapshot = subjectTriggerPoint.Value.Snapshot;
            SnapshotSpan querySpan = new SnapshotSpan(subjectTriggerPoint.Value, 0);

            //look for occurrences of our QuickInfo words in the span
            ITextStructureNavigator navigator = m_provider.NavigatorService.GetTextStructureNavigator(m_subjectBuffer);
            TextExtent extent = navigator.GetExtentOfWord(subjectTriggerPoint.Value);
            string searchText = extent.Span.Snapshot.GetText();

            applicableToSpan = currentSnapshot.CreateTrackingSpan
                (
                    extent.Span.Start, extent.Span.GetText().Length, SpanTrackingMode.EdgeInclusive
                );
            
            bool appropriateTypeIsFound = false;

            foreach (List<string> type in SettingsLoader.getSpecs())
            {
                List<SnapshotSpan> wordSpansTemp = new List<SnapshotSpan>();
                FindData findData = new FindData(extent.Span.GetText(), extent.Span.Snapshot);
                findData.FindOptions = FindOptions.WholeWord | FindOptions.MatchCase;
                wordSpansTemp.AddRange(m_textSearchService.FindAll(findData));
                List<SnapshotSpan> wordSpansTemp2 = new List<SnapshotSpan>();

                for (int i = 1; i < type.Count; i++)
                {
                    string temp = type[i].Replace("%name%", extent.Span.GetText());

                    findData = new FindData(temp, extent.Span.Snapshot);
                    wordSpansTemp2.AddRange(m_textSearchService.FindAll(findData));
                }

                if (wordSpansTemp.Count == wordSpansTemp2.Count)
                {
                    qiContent.Add(type[0]);
                    appropriateTypeIsFound = true;
                }
            }

            if (!appropriateTypeIsFound)
                applicableToSpan = null;
        }

        private bool m_isDisposed;
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                GC.SuppressFinalize(this);
                m_isDisposed = true;
            }
        }
    }

    [Export(typeof(IQuickInfoSourceProvider))]
    [Name("ToolTip QuickInfo Source")]
    [Order(After = "Default Quick Info Presenter")]
    [ContentType("text")]
    internal class QuickInfoSourceProvider : IQuickInfoSourceProvider
    {
        [Import]
        internal ITextSearchService TextSearchService { get; set; }

        [Import]
        internal ITextStructureNavigatorSelectorService NavigatorService { get; set; }

        [Import]
        internal ITextBufferFactoryService TextBufferFactoryService { get; set; }

        public IQuickInfoSource TryCreateQuickInfoSource(ITextBuffer textBuffer)
        {
            return new QuickInfoSource(this, textBuffer, TextSearchService);
        }
    }

    internal class QuickInfoController : IIntellisenseController
    {
        private ITextView m_textView;
        private IList<ITextBuffer> m_subjectBuffers;
        private QuickInfoControllerProvider m_provider;
        private IQuickInfoSession m_session;

        internal QuickInfoController(ITextView textView, IList<ITextBuffer> subjectBuffers, QuickInfoControllerProvider provider)
        {
            m_textView = textView;
            m_subjectBuffers = subjectBuffers;
            m_provider = provider;

            m_textView.MouseHover += this.OnTextViewMouseHover;
        }

        private void OnTextViewMouseHover(object sender, MouseHoverEventArgs e)
        {
            //find the mouse position by mapping down to the subject buffer
            SnapshotPoint? point = m_textView.BufferGraph.MapDownToFirstMatch
                 (new SnapshotPoint(m_textView.TextSnapshot, e.Position),
                PointTrackingMode.Positive,
                snapshot => m_subjectBuffers.Contains(snapshot.TextBuffer),
                PositionAffinity.Predecessor);

            if (point != null)
            {
                ITrackingPoint triggerPoint = point.Value.Snapshot.CreateTrackingPoint(point.Value.Position,
                PointTrackingMode.Positive);

                if (!m_provider.QuickInfoBroker.IsQuickInfoActive(m_textView))
                {
                    m_session = m_provider.QuickInfoBroker.TriggerQuickInfo(m_textView, triggerPoint, true);
                }
            }
        }

        public void Detach(ITextView textView)
        {
            if (m_textView == textView)
            {
                m_textView.MouseHover -= this.OnTextViewMouseHover;
                m_textView = null;
            }
        }

        public void ConnectSubjectBuffer(ITextBuffer subjectBuffer)
        {
        }

        public void DisconnectSubjectBuffer(ITextBuffer subjectBuffer)
        {
        }
    }

    [Export(typeof(IIntellisenseControllerProvider))]
    [Name("ToolTip QuickInfo Controller")]
    [ContentType("text")]
    internal class QuickInfoControllerProvider : IIntellisenseControllerProvider
    {
        [Import]
        internal IQuickInfoBroker QuickInfoBroker { get; set; }

        public IIntellisenseController TryCreateIntellisenseController(ITextView textView, IList<ITextBuffer> subjectBuffers)
        {
            return new QuickInfoController(textView, subjectBuffers, this);
        }
    }
}
