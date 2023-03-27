using Assignment.Presenters;

namespace Assignment.UseCases
{
    public class NullCommand
    {
        public NullCommand()
        {

        }

        public IPresenter Execute()
        {
            return new NullPresenter();
        }
    }
}
