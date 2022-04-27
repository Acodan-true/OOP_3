using Microsoft.EntityFrameworkCore;
using OOP_3.Models;
using OOP_3.Services;
using OOP_3.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<IBookContext, BookContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IBookService, BookService>();

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
/*
Сделать библиотеку с книгами. Сущность - книга
Создать интерфейс взаимодействия - контракт, по 
которому клиент будет взаимодейтвовать с нами:
POST /books, Тело — объект. Отвечает за
сохранение полностью нового объекта книги.
PUT /books/id, Тело — объект. 
Отвечает за изменение уже существующей 
книги, с определенным id 
DELETE /books/id, Тело — пустое. Отвечает
за удаление существующей книги с определенным id.
GET /books/id, Тело — пустое. 
Отвечает за получение данных по книгес определенным id.
GET /books, Тело — пустое. Отвечает за получение 
списка всех книг.
Архитектура:
1. Контроллер — принимает и обрабатывает запросы клиента. 
2. Репозиторий — делает простейшие операции с БД, ему
скомандовали сохранить — он сохранил, скомандовали удалить — он удалил. 
3. Сервис — решает, как поступать с тем или иным запросом.
А вдруг клиент удаляет или изменяет несуществующую запись?
А вдруг какие-то данные нельзя менять? Задача сервиса — принять
запрос и отдать нужные команды репозиторию. 
*/