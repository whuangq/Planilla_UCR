using Microsoft.JSInterop;
using Presentation.Employers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Employers.XLS
{
    public class Excel
    {
        public async Task GenerateExcelReport2Async(IJSRuntime js, ProjectHistorical[] data, string filename = "Reporte histórico pagos por proyecto.xlsx")
        {
            var report3 = new ProjectHistoricalExcel();
            string XLSStream = report3.Edition(data);

            await js.InvokeVoidAsync("jsSaveAsFile", filename, XLSStream);
        }
    }
}