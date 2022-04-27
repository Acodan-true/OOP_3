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
������� ���������� � �������. �������� - �����
������� ��������� �������������� - ��������, �� 
�������� ������ ����� ���������������� � ����:
POST /books, ���� � ������. �������� ��
���������� ��������� ������ ������� �����.
PUT /books/id, ���� � ������. 
�������� �� ��������� ��� ������������ 
�����, � ������������ id 
DELETE /books/id, ���� � ������. ��������
�� �������� ������������ ����� � ������������ id.
GET /books/id, ���� � ������. 
�������� �� ��������� ������ �� ������ ������������ id.
GET /books, ���� � ������. �������� �� ��������� 
������ ���� ����.
�����������:
1. ���������� � ��������� � ������������ ������� �������. 
2. ����������� � ������ ���������� �������� � ��, ���
������������ ��������� � �� ��������, ������������ ������� � �� ������. 
3. ������ � ������, ��� ��������� � ��� ��� ���� ��������.
� ����� ������ ������� ��� �������� �������������� ������?
� ����� �����-�� ������ ������ ������? ������ ������� � �������
������ � ������ ������ ������� �����������. 
*/