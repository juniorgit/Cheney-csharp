## A carta na manga que é pura matemática
### Como o norte-americano William Fitch Cheney criou há 83 anos seu truque com o baralho

<img src="https://market.com.br/files/junior/cheney1.jpg"/>
 
Um dos truques de adivinhação com cartas mais criativos já inventados continua a atrair a atenção dos matemáticos quase um século após sua primeira apresentação.

Criado em 1920 pelo contador californiano _William Fitch Cheney Jr._, esse número de "mágica" com ares de telepatia atrai pesquisadores que atuam em áreas como a da Teoria da Informação e a Teoria dos Códigos, amplamente usadas na elaboração de software.

Na apresentação do truque, alguém da platéia escolhe cinco cartas entre as 52 de um baralho, sem mostrar ao mágico. Sua assistente lhe mostra quatro delas, e ele adivinha qual é a quinta.

Coisa do sobrenatural? A matemática diz que não. Se o mágico tivesse de adivinhar qual das 48 cartas restantes é a escolhida, seria claramente impossível. Mas o ilusionista usa um código de comunicação com sua fiel assistente para impressionar a platéia. Usando a Teoria da Informação e outros recursos matemáticos, ela pode "dedar" ao mágico qual é a quinta carta, apenas pela ordem em que mostra as quatro primeiras.

A idéia básica do truque, a compactação da informação, também é usada em programas de computador como o popular Winzip. Repare que, usando apenas quatro cartas, a assistente consegue passar informação sobre cinco delas a seu chefe. Ela faz com as cartas o mesmo que um software faz com os bits, as unidades de informação usadas em computação.

A inteligência matemática de "Fitch, o mágico", criador do truque, não impressionou apenas seus amigos e alunos de cálculo. Mais tarde, outras de suas idéias lhe renderam o primeiro diploma de doutorado em matemática concedido pelo prestigiado MIT, o Instituto de Tecnologia de Massachusetts, nos EUA.

A história do truque andava meio esquecida e foi recuperada no fim do ano passado pelo matemático Michael Kleber, da Universidade Brandeis. "Enquanto Fitch se dedicava à matemática, apenas a comunidade dos mágicos conservou seu truque, mas atualmente ele está na pauta dos matemáticos", conta o pesquisador.

A mágica da adivinhação da quinta carta ilustra um dos problemas estudados pela Teoria da Informação e pela Teoria dos Códigos: achar o mínimo de sinais necessários para que um codificador consiga passar uma informação a um decodificador. Elas estudam também maneiras de se transmitir e receber mensagens facilmente legíveis.

As duas teorias surgiram juntas em 1948, baseadas no estudo da comunicação por meios elétricos, como o telégrafo. Hoje, ambas são aproveitadas em pesquisas sobre todo tipo de comunicação, não importa se escrita ou falada, analógica ou digital - desde a simples conversa entre duas pessoas próximas até a transmissão de dados via satélite. 

### A "adivinhação" da quinta carta

<img src="https://market.com.br/files/junior/cheney2.jpg"/>

Em um baralho há quatro naipes: ouros, espadas, copas e paus. Se escolhermos cinco cartas ao acaso, pelo menos duas delas serão do mesmo naipe. Suponhamos que as cartas escolhidas sejam: 2 de paus, 4 de copas, 8 de espadas, 10 de paus e dama de ouros (foto à direita). A assistente deve escolher uma daquelas com naipe repetido para ser a primeira mostrada ao mágico. Isso é para sinalizar que a quinta também será desse naipe (no caso, paus).

O que as três cartas seguintes vão sinalizar é o valor da quinta. Isso será feito mostrando qual o intervalo do valor entre a primeira e a última carta.

As cartas dentro de cada naipe seguem um círculo fechado e contínuo, ou seja, depois do A (ás, carta de valor mais baixo) vêm 2, 3, 4, 5, 6, 7, 8, 9, 10, J (valete), Q (dama), K (rei), e a contagem recomeça do A (ás).

Assim, o intervalo menor entre duas cartas nunca será maior que seis. Do 2 ao 10 de paus contam-se oito unidades, mas do 10 ao 2, são apenas cinco (J-Q-K-A-2). Nesse caso, a primeira carta tem de ser o 10, pois a contagem do intervalo deve ser sempre feita para frente, e nunca deve exceder seis. Agora, o segredo está na seqüência em que as três cartas seguintes são mostradas, e no valor de cada uma delas. Uma dessas cartas tem valor pequeno (P), outra médio (M) e outra grande (G), por isso podem ser arranjadas em seis seqüências diferentes. Cada seqüência indica um intervalo de tamanho diferente entre a primeira e a quinta cartas. O mágico e sua assistente podem combinar o seguinte código:

Ordem | Sequência
------------ | -------------
PMG | 1 
PGM | 2 
MPG | 3 
MGP | 4 
GPM | 5
GMP | 6

Aplicando a regra ao exemplo acima, a primeira carta mostrada deve ser o 10 de paus. Para dizer que a quinta carta será o 2 de paus (cinco unidades depois do 10), o código é "grande-pequeno-médio", e as cartas devem ser mostradas assim: dama de ouros (a carta que tem o maior valor das três), 4 de copas (o menor valor) e 8 de espadas (valor médio).

Pode haver, nas cartas escolhidas, repetição de algumas de mesmo valor, mas com naipe diferente. Nesse caso, vale a ordem crescente segundo a seqüência de naipes: ouros (o mais baixo), espadas, copas e paus (o mais alto). Por exemplo: o 8 de ouro vale menos que o 8 de espadas e o rei de copas vale menos que o rei de paus.

Para o truque sair rápido, é necessário que o código seja bem decorado pelo mágico e por sua assistente.

***

### Veja se você aprendeu

#### 1) Se sua assistente mostrar a você as quatro cartas conforme a sequência abaixo (da esquerda para a direita), qual deverá ser a quinta carta?
<img src="https://market.com.br/files/junior/cheney3.jpg"/>


#### 2) E se a sequência for esta?
<img src="https://market.com.br/files/junior/cheney4.jpg"/>
 
<br/><br/>
>Respostas: 1) 8 de ouros 2) 10 de espadas

***
### Fonte
>Matéria escrita por Carmem Kawano<br/>
>[Página da revista Galileu](http://revistagalileu.globo.com/Galileu/0,6993,ECT545764-2680,00.html)

### Código 
Neste projeto encontra-se o código fonte em C# que mostra como implementar a parte da assistente (escolher a ordem das cartas) e também do mágico (tentar acertar).
