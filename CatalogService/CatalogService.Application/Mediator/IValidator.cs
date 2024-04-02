using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Mediator
{
    /// <summary>
    /// Интерфейс для объявления валидации для использования в <see cref="ValidationBehaviour"/>
    /// </summary>
    /// <typeparam name="T">Валидатор команды / запроса</typeparam>
    public interface IValidator<T> where T : IBaseRequest
    {
        /// <summary>
        /// Валидация команды / запроса
        /// </summary>
        /// <param name="request">Команда / запрос</param>
        /// <returns>Результат Валидации</returns>
        Result Validate(T request);
    }
}
