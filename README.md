# 📚 Bookshelf API

> REST API для управления библиотекой книг. Проект создан для портфолио.

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-336791)
![License](https://img.shields.io/badge/License-MIT-green)
![Tests](https://img.shields.io/badge/Tests-Passing-brightgreen)

---

## 📸 Демонстрация

Swagger документация доступна по адресу `/swagger`.

---

## ⚙️ Стек технологий

- **C# 12 + .NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core** (ORM)
- **PostgreSQL** (база данных)
- **Swagger** (документация API)
- **xUnit + Moq** (юнит-тестирование)

---

## 📋 Эндпоинты

| Метод | URL | Описание |
|-------|-----|----------|
| `GET` | `/api/books` | Получить все книги |
| `GET` | `/api/books?genre=роман` | Фильтрация по жанру |
| `GET` | `/api/books/{id}` | Получить книгу по ID |
| `POST` | `/api/books` | Добавить книгу |
| `PUT` | `/api/books/{id}` | Обновить книгу |
| `DELETE` | `/api/books/{id}` | Удалить книгу |

---

## 🚀 Как запустить локально

```bash
# 1. Клонировать репозиторий
git clone https://github.com/твой-ник/bookshelf-api.git

# 2. Перейти в папку проекта
cd bookshelf-api

# 3. Восстановить базу данных (нужен PostgreSQL)
Update-Database

# 4. Запустить проект
dotnet run
