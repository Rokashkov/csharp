using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    abstract internal class Handler             //Хендлер всех возможных исключений
    {
        public delegate void Callback();

        static public void Handle(Callback callback)
        {
            /*
                Тут можно было в каждый кетч дописать уникальную логику,
                но меня вполне устраивает дефолтное сообщение исключения.
                Просто проглядел инстансы разных исключений на наличие уникальных полей и вывел их.
            */

            try
            {
                callback();
            }
            catch (UnauthorizedAccessException exc)
            {
                Logger.LogException(exc);
            }
            catch (PlatformNotSupportedException exc)
            {
                Logger.LogException(exc);
            }
            catch (NotSupportedException exc)
            {
                Logger.LogException(exc);
            }
            catch (ArgumentNullException exc)
            {
                Console.WriteLine(exc.ParamName);

                Logger.LogException(exc);
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine(exc.ParamName);

                Logger.LogException(exc);
            }
            catch (FileNotFoundException exc)
            {
                Console.WriteLine(exc.FileName);
                Console.WriteLine(exc.FusionLog);

                Logger.LogException(exc);
            }
            catch (DirectoryNotFoundException exc)
            {
                Logger.LogException(exc);
            }
            catch (PathTooLongException exc)
            {
                Logger.LogException(exc);
            }
            catch (IOException exc)
            {
                Logger.LogException(exc);
            }
            catch (OutOfMemoryException exc)
            {
                Logger.LogException(exc);
            }
            catch (FormatException exc)
            {
                Logger.LogException(exc);
            }
            catch (InvalidDataException exc)
            {
                Logger.LogException(exc);
            }
            catch (Exception exc)
            {
                Logger.LogException(exc);
            }
        }
    }
}
