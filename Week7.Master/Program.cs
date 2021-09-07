using System;
using Week7.Master.Core.BusinessLayer;
using Week7.Master.Core.Entities;
using Week7.Master.RepositoryMock;

namespace Week7.Master
{
    class Program
    {
        //accedo alle Repository ,creo un oggetto della classe IBusinessLayer , cosi posso connetermi ad repository, quelli finti ora
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryCorsiMock(), new RepositoryDocentiMock(), new RepositoryStudentiMock(), new RepositoryLezioniMock());

        static void Main(string[] args)
        {
            bool continua = true;
            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);

            }
        }
        private static int SchermoMenu()
        {
            Console.WriteLine("******************** Menu ********************");
            //Funzionalita sui corsi
            Console.WriteLine("\nFunzonalita CORSI:");
            Console.WriteLine("1. Visualizza tutti i corsi.");
            Console.WriteLine("2. Inserisci nuovo corso.");
            Console.WriteLine("3. Modifica corso.");
            Console.WriteLine("4. Elimina corso.");

            //Funzionalita sui corsi
            Console.WriteLine("\nFunzonalita DOCENTI:");
            Console.WriteLine("5. Visualizza tutti i docenti.");
            Console.WriteLine("6. Inserisci nuovo docente.");
            Console.WriteLine("7. Modifica docente.");
            Console.WriteLine("8. Elimina docente.");

            //Funzionalità su Lezioni
            Console.WriteLine("\nFunzionalità Lezioni:");
            Console.WriteLine("9. Visualizza elenco delle lezioni completo");
            Console.WriteLine("10. Inserimento nuova lezione");
            Console.WriteLine("11. Modifica lezione");//per semplicità solo modifica Aula
            Console.WriteLine("12. Elimina lezione");
            Console.WriteLine("13. Visualizza le Lezioni di un Corso ricercando per Codice del Corso");
            Console.WriteLine("14. Visualizza le Lezioni di un Corso ricercando per Nome del Corso");

            //Funzionalità su Studenti
            Console.WriteLine("\nFunzionalità Studenti:");
            Console.WriteLine("15. Visualizza l'elenco completo degli studenti");
            Console.WriteLine("16. Inserimento nuovo Studente");
            Console.WriteLine("17. Modifica Studente");//per semplicità solo email
            Console.WriteLine("18. Elimina Studente");
            Console.WriteLine("19. Visualizza l'elenco degli studenti iscritti ad un corso");

            //Exit
            Console.WriteLine("\n0. Exit");
            Console.WriteLine("********************************************");


            int scelta;
            Console.Write("Inserisci scelta: ");
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 19)
            {
                Console.Write("\nScelta errata. Inserisci scelta corretta: ");
            }
            return scelta;
        }
        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    VisualizzaCorsi();
                    break;
                case 2:
                    InserisciNuovoCorso();
                    break;
                case 3:
                    ModificaCorso();
                    break;
                case 4:
                    EliminareCorso();
                    break;
                case 5:
                    VisualizzaDocenti();
                    break;
                case 6:
                    InserisciNuovoDocente();
                    break;
                case 7:
                    ModificaDocente();
                    break;
                case 8:
                    EliminaDocente();
                    break;
                case 9:
                    VisualizzaLezioni();
                    break;
                case 10:
                    //InserisciNuovaLezione();
                    break;
                case 11:
                    //ModificaLezione();
                    break;
                case 12:
                    //EliminaLezione();
                    break;
                case 13:
                    //VisualizzaLezioneConCodiceCorso();
                    break;
                case 14:
                    //VisualizzaLezionePerIlNomeCorso();
                    break;
                case 15:
                    VisualizzaStudenti();
                    break;
                case 16:
                    InserisciNuovoStudente();
                    break;
                case 17:
                    ModificaStudente();
                    break;
                case 18:
                    EliminaStudente();
                    break;
                case 19:
                    VisualizzaStudentiIscritti();
                    break;
                case 0:                   
                    return false;
            }
            return true;
        }

        private static void VisualizzaLezioni()
        {
            var lezioni = bl.GetAllLezioni();
            if (lezioni.Count == 0)
            {
                Console.WriteLine("Non ci sono lezioni da visualizzare!");
            }
            else
            {
                Console.WriteLine("Le lezioni sono:");
                foreach (var l in lezioni)
                {
                    Console.WriteLine(l.ToString());
                }
            }
        }

        private static void EliminaDocente()
        {
            VisualizzaDocenti();          
            int id;
            do
            {
                Console.WriteLine("Scegli ID del docente che vorresti cancellare:");

            } while (!int.TryParse(Console.ReadLine(),out id));
            string esito = bl.EliminaDocente(id);
            Console.WriteLine(esito);
        }

        private static void ModificaDocente()
        {
            String nome = String.Empty;
            String cognome = String.Empty;
            String email = String.Empty;
            int id;
            Console.WriteLine("Ecco elenco dei docenti:");
            VisualizzaDocenti();

            do
            {
                Console.WriteLine("Quale docente vuoi modificare?Inserisci Id:");

            } while (!int.TryParse(Console.ReadLine(), out id));

            do
            {
                Console.WriteLine("Inserisce nuovo nome:");
                nome = Console.ReadLine();

            } while (String.IsNullOrEmpty(nome));
            do
            {
                Console.WriteLine("Inserisce nuovo cognome:");
                cognome = Console.ReadLine();

            } while (String.IsNullOrEmpty(cognome));
            do
            {
                Console.WriteLine("Inserisce nuovo e-mail:");
                email = Console.ReadLine();

            } while (String.IsNullOrEmpty(email));

            var esito = bl.ModificaDocente(id,nome,cognome,email);
            Console.WriteLine(esito);

        }

        private static void InserisciNuovoDocente()
        {
            String nome = String.Empty;
            String cognome = String.Empty;
            String email = String.Empty;
            String telefono = String.Empty;

            do
            {
                Console.WriteLine("Inserisci il nome:");
                nome = Console.ReadLine();

            } while (String.IsNullOrEmpty(nome));

            do
            {
                Console.WriteLine("Inserisci il cognome:");
                cognome = Console.ReadLine();

            } while (String.IsNullOrEmpty(cognome));

            do
            {
                Console.WriteLine("Inserisci e-mail:");
                email = Console.ReadLine();

            } while (String.IsNullOrEmpty(email));

            do
            {
                Console.WriteLine("Inserisci il telefono:");
                telefono = Console.ReadLine();

            } while (String.IsNullOrEmpty(telefono));

            Docente nuovoDocente = new Docente()
            {
                Nome = nome,
                Cognome = cognome,
                Email = email,
                Telefono = telefono
            };

            var esito = bl.InserisciNuovoDocente(nuovoDocente);
            Console.WriteLine(esito);
        }

        private static void VisualizzaDocenti()
        {
            var docenti = bl.GetAllDocenti();
            if (docenti.Count == 0)
            {
                Console.WriteLine("Non ci sono docenti da visualizzare!");
            }
            else
            {
                Console.WriteLine("I docenti presenti sono:");
                foreach (var d in docenti)
                {
                    Console.WriteLine(d.ToString());
                }
            }
        }

        private static void VisualizzaStudentiIscritti()
        {
            VisualizzaCorsi();
            string scelta;
            Console.WriteLine("Di quale corso vuoi vedere i studenti?!");
            scelta = Console.ReadLine();

            var esito = bl.VisualizzaStudentiCorso(scelta);
            if (esito == null)
            {
                Console.WriteLine("Errore della Lista!");
            }
            else if (esito.Count == 0)
            {
                Console.WriteLine("Non ci sono i studenti da visualizzare!");
            }
            else
            {
                foreach (var c in esito)
                {
                    Console.WriteLine(c);
                }
            }          
        }

        private static void EliminaStudente()
        {          
            VisualizzaStudenti();
            int id;
            do
            {
                Console.WriteLine("Scegli ID dello studente che vorresti cancellare:");

            } while (!int.TryParse(Console.ReadLine(),out id));
            string esito = bl.EliminaStudente(id);
            Console.WriteLine(esito);
        }

        private static void ModificaStudente()
        {
            String nuovoEmail;
            int id;
            Console.WriteLine("Ecco elenco dei studenti:");
            VisualizzaStudenti();

            do
            {
                Console.WriteLine("Quale studente vuoi modificare?Inserisci Id:");

            } while (!int.TryParse(Console.ReadLine(),out id));
          
            do
            {
                Console.WriteLine("Inserisci nuovo e-mail dello studente:");
                nuovoEmail = Console.ReadLine();

            } while (String.IsNullOrEmpty(nuovoEmail));
            var esito = bl.ModificaStudente(id, nuovoEmail);
            Console.WriteLine(esito);
        }

        private static void InserisciNuovoStudente()
        {
            string nome, cognome, titoloStudio, email;
            DateTime dt = new DateTime();

            Console.WriteLine("Inserisci nome:");
            nome = Console.ReadLine();

            Console.WriteLine("Inserisci cognome:");
            cognome = Console.ReadLine();

            Console.WriteLine("Inserisci email:");
            email = Console.ReadLine();

            Console.WriteLine("Inserisci data di nascita:(formato aaaa-mm-gg)");
            dt = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci titolo studio:");
            titoloStudio = Console.ReadLine();

            VisualizzaCorsi();
            Console.WriteLine("Inserisci codice corso a cui e iscritto:");
            string codiceCorso = Console.ReadLine();

            Studente nuovoStudente = new Studente()
            {
                Nome = nome,
                Cognome = cognome,
                Email = email,
                DataDiNascita = dt,
                TitoloStudio = titoloStudio,
                CorsoCodice = codiceCorso
            };

            var esito = bl.InserisciNuovoStudente(nuovoStudente);
            Console.WriteLine(esito);
        }

        private static void VisualizzaStudenti()
        {
            var studenti = bl.GetAllStudenti();
            if (studenti.Count == 0)
            {
                Console.WriteLine("Non ci sono studenti da visualizzare!");
            }
            else
            {
                Console.WriteLine("I studenti presenti sono:");
                foreach (var student in studenti)
                {
                    Console.WriteLine(student.ToString()); 
                }
            }
        }

        private static void EliminareCorso()
        {
            Console.WriteLine("Scegli il codice del corso che vorresti cancellare:");
            VisualizzaCorsi();
            string codice = Console.ReadLine();
            string esito = bl.EliminaCorso(codice);
            Console.WriteLine(esito);
        }

        private static void ModificaCorso()
        {
            String nuovoNome, nuovaDescrizione;
            Console.WriteLine("Ecco elenco dei corsi da modificare:");
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi modificare?");
            string codice = Console.ReadLine();
            do
            {
                Console.WriteLine("Inserisci il nome del corso:");
                nuovoNome = Console.ReadLine();

            } while (String.IsNullOrEmpty(nuovoNome));

            do
            {
                Console.WriteLine("Inserisci la descrizione del corso:");
                nuovaDescrizione = Console.ReadLine();

            } while (String.IsNullOrEmpty(nuovaDescrizione));

            var esito = bl.ModificaCorso(codice, nuovoNome, nuovaDescrizione);
            Console.WriteLine(esito);
        }

        private static void InserisciNuovoCorso()
        {
            //Chiedo i dati per creare il corso
            String codice, nome, descrizione;

            do
            {
                Console.WriteLine("Inserisci il codice del corso:");
                codice = Console.ReadLine();

            } while (String.IsNullOrEmpty(codice));

            do
            {
                Console.WriteLine("Inserisci il nome del corso:");
                nome = Console.ReadLine();

            } while (String.IsNullOrEmpty(nome));

            do
            {
                Console.WriteLine("Inserisci la descrizione del corso:");
                descrizione = Console.ReadLine();

            } while (String.IsNullOrEmpty(descrizione));
            

            //creo un nuovo corso
            Corso nuovoCorso = new Corso()
            {
                CodiceCorso = codice,
                Nome = nome,
                Descrizione = descrizione
            };

            //lo passo al Business Layer per controllare i dati ed aggiungerlo poi nel DB
            string esito = bl.InserisciNuovoCorso(nuovoCorso);
            Console.WriteLine(esito);
        }

        private static void VisualizzaCorsi()
        {
            var corsi = bl.GetAllCorsi();
            if (corsi.Count == 0) // count fa vedere quanti elemnti ci sono nella lista,se ci sono 
            {
                Console.WriteLine("Non ci sono corsi da visualizzare!");
            }
            else
            {
                Console.WriteLine("I corsi disponibili sono:");
                foreach (var corso in corsi)
                {
                    Console.WriteLine(corso.ToString()); // oppure solo (item) --> e mi stampa il mio print ToString()
                }
            }
          
        }
    }
}
