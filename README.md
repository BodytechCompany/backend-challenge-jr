![Bodytech Company](https://lh3.googleusercontent.com/XGAFWh7M4Gvsn8UBAD41pm_S1WiCOpCCBxtgdeM1w1LD68F5SZZ5r4YoQynq97l-LcBDFdj3Uwk=s900 "www.bodytech.com.br") 

# Desafio Backend JR
Olá! Se você chegou até aqui é porque foi aprovado(a) na nossa primeira etapa da entrevista para a vaga de DevNinja BT.

Ótimo! E Parabéns!!! :clap::clap::clap:

Bom, você deve lembrar do nosso estudo de caso, certo? O nosso desafio vai usá-lo como base, mas de uma forma bem simplificada. :wink:

O desafio consiste em criar uma API para o acesso e alteração da ficha de treino do cliente através do nosso aplicativo (Android e iOS).
Para simplificar o desenvolvimento, vamos retirar a complexidade da ficha de treino poder ter mais de uma série associada (A, B e/ ou C) e entender, como regra de negócio, que a ficha é apenas uma lista com exercícios/ equipamentos associada a um cliente e professor.


**_Para ajudar no entendimento, o MER de um BD ficaria mais ou menos assim:_**

![MER - Modelo Entidade Relacionamento](https://lh3.googleusercontent.com/MjoXFbh9pNPcBsaHcZwx0bdtQ-CrV_BEGMNrnoQYe_WHlLqN0cJY0zvT6wsKA1jqqXpIbaxRXSg "MER - Modelo Entidade Relacionamento")



**_Exemplo da Ficha de Treino do cliente:_**

![Ficha de Treino](https://lh3.googleusercontent.com/k35lCLH5uI4Ywrw1c_6uIiRJ9X-TSBrCi2mN2yWNtJkWtssehbUaQSzemTGMoSM_54iNsIZO6NY=s500 "Ficha de Treino")


### Você deverá desenvolver uma API para o CRUD da Ficha de Treino, entendendo que:
 1. O professor tem permissão de visualizar, incluir, alterar e deletar os exercícios da ficha de treino de qualquer cliente.
 2. O professor pode incluir uma lista de exercícios ou um exercício por vez para o cliente.
 3. O professor pode pesquisar a ficha do cliente por nome e/ ou matrícula.
 4. O cliente tem permissão de visualizar e alterar (somente a informação de carga) apenas a sua ficha de treino


## Instruções
 1. Efetue o **fork** deste projeto para a sua conta do GitHub.
 2. Implemente o desafio da **API** apresentado acima.
 3. Após finalizar o desafio crie um **Pull Request**.
 4. Você deverá apresentar a sua solução para o nosso CTO Ninja.


## Requisitos
 - Escolha livre da linguagem para desenvolvimento
 - Escolha livre do framework para desenvolvimento
 - Escolha livre para efetuar a persistência dos dados (BD, JSON, XML, ...)
 - Gestão de dependências via gerenciador de pacote
 - Prazo de 4 (quatro) dias corridos


## Documentação
 - No README do projeto explique:
	 - Funcionamento e arquitetura da solução.
	 - Passos para execução do projeto.


## Diferencial
 - API RestFull
 - Tratamento de erros
 - Teste unitário
 - Uso de JWT
 - Elaboração da documentação dos endpoints
 - Elaboração do front-end
 - Pensar em uma arquitetura escalável (não é necessário programar, apenas descrever como seria)


## Dúvidas
Se surgir alguma dúvida, consulte as  [perguntas feitas anteriormente](https://github.com/BodytechCompany/backend-challenge/labels/question).

Caso não encontre a sua resposta, sinta-se à vontade para  [abrir uma issue](https://github.com/BodytechCompany/backend-challenge/issues/new)  =]
