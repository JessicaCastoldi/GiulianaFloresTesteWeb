using System.Diagnostics.CodeAnalysis;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
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
            driver.FindElement(By.XPath("//*[@id='ContentSite_uppProducts']/ul/li[2]/div/a/h2")).Click();
        }
[Then(@"exibe a pagina ""(.*)""")]
        public void ThenExibeAPagina(string titleAzaleiaRosa )
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));
            wait.Until(d => driver.FindElement(By.ClassName("jq-product-name")));
            Assert.That(driver.FindElement(By.ClassName("jq-product-name")).Text,
                                          Is.EqualTo(titleAzaleiaRosa).IgnoreCase);

        }
     
     [Then(@"valido o nome do produto ""(.*)""")]
        public void ThenValidoONomeDoProduto(string nomeProduto)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));
            wait.Until(d => driver.FindElement(By.ClassName("jq-product-name")).Displayed);
            Assert.That(driver.FindElement(By.ClassName("jq-product-name")).Text,Is.EqualTo(nomeProduto).IgnoreCase);
        }


      [Then(@"valido o preço do produto ""(.*)""")]
        public void ThenValidoOPrecoDoProduto(string preco)
        {
            Assert.That(driver.FindElement(By.CssSelector("span.precoPor_prod")).Text,Is.EqualTo(preco));
        }

        
    }
}