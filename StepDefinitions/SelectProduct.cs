using System.Diagnostics.CodeAnalysis;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace GiulianaFloresTesteWeb
{
    [Binding]

    public class StepDefinitions{

        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;

        public object ExpectedConditions { get; private set; }

        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
             driver = (IWebDriver) _scenarioContext["driver"];
                    
        }

        [Given(@"que acesso a pagina inicial do site")]
           public void GivenQueAcessoAPaginaInicialDoSite()
        {
            driver.Navigate().GoToUrl("https://www.giulianaflores.com.br");
        }

    [When(@"pesquiso o produto ""(.*)""")]
    public void WhenPesquisoOProduto(string azaleia)
        {
            IWebElement campoPesquisa = driver.FindElement(By.Id("txtDsKeyWord"));
            campoPesquisa.SendKeys(azaleia);
            driver.FindElement(By.Id("btnSearch")).Click();
        }
   

     [When(@"clico no produto escolhido")]
      public void WhenClicoNoProdutoEscolhido()
        {
            driver.FindElement(By.ClassName("close-button")).Click();
            driver.FindElement(By.CssSelector("h2.title-item")).Click();
        }
[Then(@"exibe a pagina ""(.*)""")]
        public void ThenExibeAPagina(string titleAzaleiaRosa )
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));
            wait.Until(d => driver.FindElement(By.CssSelector
            ("a[href=https://www.giulianaflores.com.br/azaleia-rosa-para-decorar/prs-3106-27055/]")).Text);
           Assert.That(driver.FindElement(By.CssSelector("a[href=\"https://www.giulianaflores.com.br/azaleia-rosa-para-decorar/prs-3106-27055/\"] h2")).Text,
                                          Is.EqualTo(titleAzaleiaRosa));

        }
     
     [Then(@"valido o nome do produto ""(.*)""")]
        public void ThenValidoONomeDoProduto(string nomeProduto)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));
            wait.Until(d => driver.FindElement(By.Id("span#ContentSite_lblProductDsName")).Displayed);
            Assert.That(driver.FindElement(By.CssSelector("span#ContentSite_lblProductDsName")).Text,Is.EqualTo(nomeProduto));
        }


      [Then(@"valido o preço do produto ""(.*)""")]
        public void ThenValidoOPrecoDoProduto(string preco)
        {
            Assert.That(driver.FindElement(By.CssSelector("span.precoPor_prod")).Text,Is.EqualTo(preco));
        }

        
    }
}