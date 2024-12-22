using FluentValidation;

using ToDo.Domain.Resources;

namespace ToDo.Application.Features.ToDoItem.Command.AddToDoItem;

public class AddBranchsCommandValidator : AbstractValidator<AddToDoItemCommand>
{
    public AddBranchsCommandValidator()
    {
        RuleFor(command => command.title)
            .NotEmpty().WithMessage(Message.ErrTitleNull);

        RuleFor(command => command.title)
    .NotEmpty().WithMessage(Message.ErrDescriptionNull);

    }
}
