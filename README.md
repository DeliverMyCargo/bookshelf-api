# Bookshelf API

REST API для управления библиотекой книг. Проект создан для портфолио.

## СТЕК ТЕХНОЛОГИЙ

- **C# 12 + .NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core (ORM)**
- **PostgreSQL (база данных)**
- **Swagger (документация API)**

## ФУНКЦИОНАЛЬНОСТЬ

- Полный CRUD (создание, чтение, обновление, удаление) для книг
- PostgreSQL в качестве базы данных
- Автоматическая документация через Swagger

## КАК ЗАПУСТИТЬ

1. Склонировать репозиторий
2. Установить PostgreSQL
3. Восстановить базу данных (Update-Database)
4. Запустить проект (F5)
5. Открыть Swagger: `/swagger`

## ПРИМЕР ЗАПРОСА (POST /api/books)

```json
{
  "title": "Мастер и Маргарита",
  "author": "Булгаков",
  "year": 1967,
  "genre": "Роман",
  "isAvailable": true
}
