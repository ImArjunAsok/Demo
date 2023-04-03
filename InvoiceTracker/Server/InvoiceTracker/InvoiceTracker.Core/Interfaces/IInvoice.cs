using InvoiceTracker.Core.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTracker.Core.Interfaces
{
    public interface IInvoice
    {
        Task<ServiceResponse<bool>> AddInvoiceAsync(AddInvoiceDto dto);

        Task<ServiceResponse<ViewProjectDto>> GetByIdInvoiceAsync(int invoiceId);

        Task<ServiceResponse<ViewProjectDto>> GetAllInvoiceAsync();

        Task<ServiceResponse<bool>> UpdateInvoiceAsync(int invoiceId, ViewInvoiceDto dto);

        Task<ServiceResponse<bool>> DeleteInvoiceAsync(int invoiceId);
    }
}
