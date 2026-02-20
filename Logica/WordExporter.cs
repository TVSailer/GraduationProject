using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Word;

namespace Logica
{
    public class WordExporter
    {
        public void WordExport<T>(List<T> elements)
        {
            if (elements == null || elements.Count == 0)
            {
                LogicaMessage.MessageOk("Отсутствуют данные для экспорта");
                return;
            }

            var wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = true;
            var wordDoc = wordApp.Documents.Add();

            InsertDataWord(wordDoc, elements);

            Marshal.ReleaseComObject(wordDoc);
            Marshal.ReleaseComObject(wordApp);
        }

        private void InsertDataWord<T>(Document wordDoc, List<T> elements)
        {

        }
    }
}
