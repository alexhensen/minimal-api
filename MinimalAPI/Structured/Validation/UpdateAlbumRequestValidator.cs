using FluentValidation;
using Structured.Contracts.Requests;

namespace Structured.Validation;

public class UpdateAlbumRequestValidator : AbstractValidator<UpdateAlbumRequest>
{
    public UpdateAlbumRequestValidator()
    {
        RuleFor(a => a.Artist).NotEmpty();
        RuleFor(a => a.Title).NotEmpty();
        RuleFor(a => a.ReleaseDate).NotEmpty();
    }
}