# Campeonato-Luta

Campeonato de luta representa uma solução para um Campeonato de Luta fictício. A solução em si contém dois projetos, sendo um projeto de backend escrito em dotnet core 5.0, e um outro projeto de front end escrito em angular 12.

## Requisitos

Os dois projetos foram escritos utilizando-se da IDE do Visual Studio Code, então, eu recomendo abrir e executar os projetos no Visual Studio Code.

* Visual Studio Code

* .NET Core Test Explorer by Jun Han, para interface gráfica de testes.

## Baixando a Solução

Para baixa a solução acesse o seguinte repositório no **GithHub**: ```https://github.com/marcos-cruz/Campeonato-Luta```.

## Instruções para Executar o Backend

* No explorer clique com o botão direito do mouse na pasta ```Backend```

* Em seguida selecione ```Open in Windows Terminal```. Se o seu sistema não está em inglês, abra a pasta backend pelo prompt.

* Digite ```code .``` e pressione Enter

* Clique com o botão direito do mouse sobre a pasta ```src\Bigai.Torneio.Luta.Api``` em seguida em ```Open Integrated Terminal```

* Digite o seguinte comando ```dotnet run```

* Para certificar que está rodando o backend, abra o seguinte endereço no browser ```https://localhost:5001/swagger/index.html```

## Instruções para Executar o Frontend

* No explorer clique com o botão direito do mouse na pasta ```Frontend\TorneioApp```

* Em seguida selecione ```Open in Windows Terminal```. Se o seu sistema não está em inglês, abra a pasta backend pelo prompt.

* Digite ```code .``` e pressione Enter

* Na parte suprior, no menu escolha ```Terminal``` depois ```New Terminal```

* Digite o comando ```npm install```

* Após concluída a instalação, digite o comando ```ng serve -o```

## Instruções para Rodar Projeto de Testes

* Clique no ícone de testes <img src="Backend\docs\icone-test.PNG" alt="Ferramenta de testes" style="height: 24px; width:24px;"/> 

Caso não tenha a extensão de testes instalado no Visual Studio code, faça o seguinte:

* Com o projeto de Backend aberto no Visual Studio Code, clique sobre a pasta ```tests\Bigai.Torneio.Api.UnitTests```, e em seguida selecione ```Open in Windows Terminal```

* Digite o comando ```dotnet test``` e digite enter.