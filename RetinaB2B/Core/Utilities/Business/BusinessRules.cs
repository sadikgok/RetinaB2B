using Core.Utilities.Result.Abstract;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }

        public static IResult Run(IResult result, IResult result1)
        {
            throw new NotImplementedException();
        }
    }
}
