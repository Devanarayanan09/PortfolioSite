using PortfolioSite.Models;

namespace PortfolioSite.Helpers
{
    public static class ContentHelpers
    {
        /// <summary>
        /// Project descriptions are stored as "• point &lt;br&gt;• point". Splits them into plain bullet strings.
        /// </summary>
        public static List<string> ToBullets(string? description)
        {
            if (string.IsNullOrWhiteSpace(description)) return new List<string>();

            return description
                .Split(new[] { "<br>", "<br/>", "<br />" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim().TrimStart('•').Trim())
                .Where(s => s.Length > 0)
                .ToList();
        }

        public static IEnumerable<string> SplitTags(string? technologies) =>
            (technologies ?? string.Empty)
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        /// <summary>Short text for an external link, e.g. "bizosuite.com" or "Google Play".</summary>
        public static string LinkLabel(string url)
        {
            if (url.Contains("play.google.com", StringComparison.OrdinalIgnoreCase)) return "Google Play";
            if (url.Contains("apps.apple.com", StringComparison.OrdinalIgnoreCase)) return "App Store";
            return url.Replace("https://", "").Replace("http://", "").Replace("www.", "").TrimEnd('/');
        }

        public static string Period(this Experience exp)
        {
            var end = exp.IsCurrent || exp.EndDate is null ? "Present" : exp.EndDate.Value.ToString("MMM yyyy");
            return $"{exp.StartDate:MMM yyyy} – {end}";
        }

        public static string Duration(this Experience exp)
        {
            var end = exp.IsCurrent || exp.EndDate is null ? DateTime.Today : exp.EndDate.Value;
            var months = (end.Year - exp.StartDate.Year) * 12 + end.Month - exp.StartDate.Month + 1;
            if (months < 1) months = 1;

            var years = months / 12;
            var rem = months % 12;
            var parts = new List<string>();
            if (years > 0) parts.Add(years == 1 ? "1 yr" : $"{years} yrs");
            if (rem > 0) parts.Add(rem == 1 ? "1 mo" : $"{rem} mos");
            return string.Join(" ", parts);
        }

        /// <summary>
        /// Appends ?v=&lt;last write ticks&gt; to a file under wwwroot so browsers pick up replaced documents.
        /// </summary>
        public static string Versioned(IWebHostEnvironment env, string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath)) return relativePath;

            var webRoot = string.IsNullOrEmpty(env.WebRootPath)
                ? Path.Combine(env.ContentRootPath, "wwwroot")
                : env.WebRootPath;

            var fullPath = Path.Combine(webRoot, relativePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
            return File.Exists(fullPath)
                ? $"{relativePath}?v={File.GetLastWriteTimeUtc(fullPath).Ticks}"
                : relativePath;
        }
    }
}
