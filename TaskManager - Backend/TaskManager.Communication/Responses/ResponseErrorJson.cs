namespace TaskManager.Communication.Responses
{
    public class ResponseErrorJson
    {
        //Classe utilizada para retornar erros no filtro de exceção

        //Os valores serão preenchidos por meio das mensagens informadas no resource dentro da classlibrary de exception.
        public List<string> ErrorMessage { get; set; }

        public ResponseErrorJson(string errorMessage)
        {

            ErrorMessage = [errorMessage];

        }

        public ResponseErrorJson(List<string> errorMessage)
        {

            ErrorMessage = errorMessage;

        }


    }
}
