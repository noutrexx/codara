using System.Collections.Generic;

namespace Codara.Application
{
    public static class AuthenticationErrorMapper
    {
        private static readonly Dictionary<string, string> Messages = new()
        {
            ["network-unavailable"] = "Bağlantı kurulamadı. Çevrimdışı devam edebilir veya daha sonra tekrar deneyebilirsin.",
            ["invalid-email"] = "E-posta adresini kontrol et.",
            ["weak-password"] = "Daha güçlü bir şifre seç.",
            ["email-already-in-use"] = "Bu e-posta ile zaten bir hesap bulunuyor.",
            ["wrong-password"] = "E-posta veya şifre eşleşmedi.",
            ["credential-already-in-use"] = "Bu giriş yöntemi başka bir hesaba bağlı.",
            ["cancelled"] = "Giriş işlemi iptal edildi."
        };

        public static string ToUserMessage(string code)
            => code != null && Messages.TryGetValue(code, out var message)
                ? message
                : "İşlem tamamlanamadı. İlerlemen güvende; daha sonra tekrar deneyebilirsin.";
    }
}
