using System.Text.Json;

using DocumentSigningSolution.Contracts.Templates;

namespace DocumentSigningSolution.Api.Controllers.Utilities.Extensions;

public static class HttpRequestExtensions
{
    public static async Task<UpdateDocumentRequest?> ParseUpdateDocumentRequestAsync(this HttpRequest request)
    {
        var contentType = request.ContentType ?? "";

        if (contentType.Contains("multipart/form-data", StringComparison.OrdinalIgnoreCase))
        {
            var form = await request.ReadFormAsync();
            return new UpdateDocumentRequest(
                form["Name"],
                form["Path"],
                form["Status"],
                form.Files["File"],
                form["TemplateId"],
                form["FolderId"]
               
            );
        }
        else
        {
            using var reader = new StreamReader(request.Body);
            var body = await reader.ReadToEndAsync();

            return JsonSerializer.Deserialize<UpdateDocumentRequest>(body, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
    
    public static async Task<UpdateTemplateRequest?> ParseUpdateTemplateRequestAsync(this HttpRequest request)
    {
        var contentType = request.ContentType ?? "";

        if (contentType.Contains("multipart/form-data", StringComparison.OrdinalIgnoreCase))
        {
            var form = await request.ReadFormAsync();
            return new UpdateTemplateRequest(
                form["Name"],
                form["Description"],
                form["Version"],
                form.Files["File"]
            );
        }
        else
        {
            using var reader = new StreamReader(request.Body);
            var body = await reader.ReadToEndAsync();

            return JsonSerializer.Deserialize<UpdateTemplateRequest>(body, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}