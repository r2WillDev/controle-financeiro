using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dima.Core.Requests.Categories
{
    public class UpdateCategoryRequest : Request
    {
        [Required(ErrorMessage = "Título Invalido")]
        [MaxLength(80, ErrorMessage = "O Titulo deve ter no máximo 80 caracteres")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descrição Invalida")]
        public string Description { get; set; } = string.Empty;
    }
}