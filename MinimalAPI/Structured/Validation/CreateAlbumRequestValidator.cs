using FluentValidation;
using Structured.Contracts.Requests;

namespace Structured.Validation;

public class CreateAlbumRequestValidator : AbstractValidator<CreateAlbumRequest>
{
    public CreateAlbumRequestValidator()
    {
        RuleFor(a => a.Artist).NotEmpty();
        RuleFor(a => a.Title).NotEmpty();
        RuleFor(a => a.ReleaseDate).NotEmpty();
    }
}