using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Moq;
using FluentAssertions;
using ToDo.Domain.Repositories;
using ToDo.Domain.Entities;
using AutoMapper;
using ToDo.Application.Features.ToDoItem.Command.AddToDoItem;

namespace ToDo.Applicaiton.Testing.ToDoItem;


public class AddToDoItemCommandHandlerTests
{
    private readonly Mock<IGenericRepository<TodoItem>> _mockRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly AddToDoItemCommandHandler _handler;

    public AddToDoItemCommandHandlerTests()
    {
        _mockRepo = new Mock<IGenericRepository<TodoItem>>();
        _mockMapper = new Mock<IMapper>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _handler = new AddToDoItemCommandHandler(_mockRepo.Object, _mockMapper.Object, _mockUnitOfWork.Object);
    }

    [Fact]
    public async Task Handle_ShouldAddTodoItemAndReturnSuccessResult()
    {
        // Arrange
        var command = new AddToDoItemCommand("Test ToDo", "Test Description", false);
        var mappedTodoItem = TodoItem.Create("Test ToDo", "Test Description", false);


        _mockMapper.Setup(m => m.Map<TodoItem>(command)).Returns(mappedTodoItem);
        _mockRepo.Setup(r => r.AddAsync(It.IsAny<TodoItem>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(u => u.SaveAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();

        _mockMapper.Verify(m => m.Map<TodoItem>(command), Times.Once);
        _mockRepo.Verify(r => r.AddAsync(mappedTodoItem, It.IsAny<CancellationToken>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldReturnFailure_WhenExceptionOccurs()
    {
        // Arrange
        var command = new AddToDoItemCommand("Test ToDo", "Test Description", false);


        _mockMapper.Setup(m => m.Map<TodoItem>(command)).Throws(new Exception("Mapping failed"));

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<Exception>().WithMessage("Mapping failed");

        _mockMapper.Verify(m => m.Map<TodoItem>(command), Times.Once);
        _mockRepo.Verify(r => r.AddAsync(It.IsAny<TodoItem>(), It.IsAny<CancellationToken>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveAsync(It.IsAny<CancellationToken>()), Times.Never);
    }
}

