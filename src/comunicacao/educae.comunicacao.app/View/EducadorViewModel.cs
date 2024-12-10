public class  EducadorViewModel 
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; } 
    public string TipoUsuario { get; set; } 
    public int Cpf { get; set; }

    public static EducadorViewModel Mapear (Educador educador) 
    {
        return new EducadorViewModel()
        {
            Nome = educador.Nome,
            Email = educador.Email,
            Senha = educador.Senha,
            TipoUsuario = educador.TipoUsuario,
            Cpf = educador.cpf
        };
    }
}