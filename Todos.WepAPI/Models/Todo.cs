﻿namespace Todos.WepAPI.Models
{
    public sealed class Todo
    {
        public int Id { get; set; }
        public string Work { get; set; } = default!;
    }
}
