using EulerLibrary2.PasswordValidator;

namespace PasswordValidator
{
    public class ExternalPasswordValidator : IPasswordValidator
    {
        //  NNNNNNNN        NNNNNNNN                                                         
        //  N:::::::N       N::::::N                                                         
        //  N::::::::N      N::::::N                                                         
        //  N:::::::::N     N::::::N                                                         
        //  N::::::::::N    N::::::N   ooooooooooo   ppppp   ppppppppp       eeeeeeeeeeee    
        //  N:::::::::::N   N::::::N oo:::::::::::oo p::::ppp:::::::::p    ee::::::::::::ee  
        //  N:::::::N::::N  N::::::No:::::::::::::::op:::::::::::::::::p  e::::::eeeee:::::ee
        //  N::::::N N::::N N::::::No:::::ooooo:::::opp::::::ppppp::::::pe::::::e     e:::::e
        //  N::::::N  N::::N:::::::No::::o     o::::o p:::::p     p:::::pe:::::::eeeee::::::e
        //  N::::::N   N:::::::::::No::::o     o::::o p:::::p     p:::::pe:::::::::::::::::e 
        //  N::::::N    N::::::::::No::::o     o::::o p:::::p     p:::::pe::::::eeeeeeeeeee  
        //  N::::::N     N:::::::::No::::o     o::::o p:::::p    p::::::pe:::::::e           
        //  N::::::N      N::::::::No:::::ooooo:::::o p:::::ppppp:::::::pe::::::::e          
        //  N::::::N       N:::::::No:::::::::::::::o p::::::::::::::::p  e::::::::eeeeeeee  
        //  N::::::N        N::::::N oo:::::::::::oo  p::::::::::::::pp    ee:::::::::::::e  
        //  NNNNNNNN         NNNNNNN   ooooooooooo    p::::::pppppppp        eeeeeeeeeeeeee  
        //                                            p:::::p                                
        //                                            p:::::p                                
        //                                           p:::::::p                               
        //                                           p:::::::p                               
        //                                           p:::::::p                               
        //                                           ppppppppp                               
                                                                                 
        public string Name => "ExternalPasswordValidator";

        public bool IsPasswordValid(string password)
        {
            return true;
        }
    }
}
