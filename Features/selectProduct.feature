Feature: Selecionar Produto na Loja
    Scenario: Selecao de Produto com Sucesso
        Given que acesso a pagina inicial do site
        When pesquiso o produto "Azaleia"
        And clico no produto escolhido
         Then exibe a pagina "Azaléia Rosa para Decorar"
        And valido o nome do produto "Azaléia Rosa para Decorar"
        And valido o preço do produto "R$ 179,90"
        




