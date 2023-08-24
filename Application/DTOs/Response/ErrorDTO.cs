namespace Application.DTOs.Response; 


public record ErrorDto(
    int StatusCode,
    string ErrorMessage
    );