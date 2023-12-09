//Bibliotecas
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

//Namespace
//Before e um After para qualquer script, não precisa se repetir é reutilizado.

namespace StepDefinitions
{

    [Binding]  //Sinaliza Marcação de que a classe segue o padrão SpecFlow 
    public class Hooks //Gancho / gatilho
    {
        //Atributos/ Objetos
        private ScenarioContext _scenarioContext;  //objeto -comunicação de vários arquivos _ interno a classe
        private IWebDriver driver; //Selenium


        //Métodos/ Funções

        public Hooks(ScenarioContext scenarioContext) 
        {
            _scenarioContext = scenarioContext;
        }

        
        [BeforeScenario]
        public void ScenarioSetup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig()); //COnfigura o driver do Chrome
            driver = new ChromeDriver(); //instancia o selenium
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000); //configuração de tempo
            driver.Manage().Window.Maximize(); //Maximiza a janela
            _scenarioContext["driver"] = driver; //Colocando o selenium dentro do contexto
            Console.WriteLine("Iniciando: " + _scenarioContext.ScenarioInfo.Title); //Mostra o título do objteto

        }

        [AfterScenario]
        public void ScenarioTearDown()
        {
            driver = (IWebDriver) _scenarioContext["driver"];
            driver.Quit();
        }
         

    }

}