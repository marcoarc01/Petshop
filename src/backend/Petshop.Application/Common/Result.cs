namespace Petshop.Application.Common
{
    public class Result<T>
    {
        public bool Sucesso { get; private set; }
        public T? Dados { get; private set; }
        public string? ErroMensagem { get; private set; }

        private Result(bool sucesso, T? dados, string? erro)
        {
            Sucesso = sucesso;
            Dados = dados;
            ErroMensagem = erro;
        }

        public static Result<T> Ok(T dados) => new Result<T>(true, dados, null);
        public static Result<T> Falha(string erro) => new Result<T>(false, default, erro);
        
    }
}