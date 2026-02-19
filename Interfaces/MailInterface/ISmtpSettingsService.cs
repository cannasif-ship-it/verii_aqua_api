using aqua_api.DTOs;

namespace aqua_api.Interfaces
{
    public interface ISmtpSettingsService
    {
        Task<ApiResponse<SmtpSettingsDto>> GetAsync();
        Task<ApiResponse<SmtpSettingsDto>> UpdateAsync(UpdateSmtpSettingsDto dto, long userId);

        // internal kullanım (mail sender)
        Task<SmtpSettingsRuntimeDto> GetRuntimeAsync();

        // update sonrası bu instance cache temizliği
        void InvalidateCache();
    }
}
