# InstagramComment

InstagramComment é uma aplicação desenvolvida em C# e automatização de testes Selenium. Esta aplicação tem por finalidade aprimorar os conhecimentos em programação.


## Como funciona o InstagramComment?

Basicamente ele é um automatizador de comentários no instagram, o core da aplicação utiliza-se a tecnologia de testes Selenium. Uma vez feito a configuração no arquivo *config.txt*, a aplicação
irá fazer o embaralhamento das contas informadas e, posteriormente, a cada intervalo de tempo randomico irá realizar o comentário na postagem do instagram. O menor intervalo detempo possível
de comentário é de 60 segundos.

Atenção, na versão 1.0.0 do InstagramComment, a aplicação comenta SEMPRE 3 contas de usuário. Melhorias serão implementadas em versões futuras.

## Como configurar o InstagramComment?

Na pasta da aplicação há um arquivo com o nome *config.txt*, nele você deve configurar as seguintes tags:

- URL_INSTAGRAM - Url do post da publicação no instagram.
- TENTATIVAS - Número de tentativas que aplicação irá tentar realizar o comentário caso encontre algum problema para efetivar o comentário.
- CONTAS - Lista de contas do instagram que a aplicação irá comentar.
- COOKIE - Cookie da conta do usuário para a aplicação fazer login e realizar o comentário.

## Como configuro o COOKIE?

Faça o login no instagram, feito isso:

<ul>
<li>1º Pressione F12.</li>
<li>2º Atualize sua página do instagram.</li>
<li>3º Na aba Network, procure pela requisição *get_encripted_credentials*</li>
<li>4º Na aba cookies, procure por *sessionid*. </li>
<li>5º Copie o valor na tag COOKIE.</li>
<li>6º Pronto :)</li>

</ul>

<a href="https://ibb.co/xq02sRm"><img src="https://i.ibb.co/VYZLNPH/Screenshot-1.png" alt="Screenshot-1" border="0"></a>

## Como sei se o InstagramComment está funcionando?

De tempos em tempos você irá ver seu browser iterando a página do instagram. Além disto, na pasta da aplicação tem dois arquivos:

- registro.txt - Grava as informações dos comentários registrados
- error.txt - Grava as informações de erro da aplicação.

## Pré requisitos da aplicação

- Possuir o browser Google Chrome, versão:  83.0.4103.116
- Sistema Operacional Windows 7, 8 e 10.

## Por fim...

Não nos responsabilizamos por danos causados por eventuais uso indevido da aplicação, sendo de total responsabilidade do usuário.
