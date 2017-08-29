Merchants Guide To The Galaxy
=========================

You decided to give up on earth after the latest financial collapse left 99.99% of the earth’s population with 0.01% of the wealth. Luckily, with the scant sum of money that is left in your account, you are able to afford to rent a spaceship, leave earth, and fly all over the galaxy to sell common metals and dirt (which apparently is worth a lot).Buying and selling over the galaxy requires you to convert numbers and units, and you decided to write a program to help you.The numbers used for intergalactic transactions follows similar convention to the roman numerals and you have painstakingly collected the appropriate translation between them.Roman numerals are based on seven symbols:

Symbol Value
I               1
V              5
X             10
L              50
C            100
D            500
M          1,000

Numbers are formed by combining symbols together and adding the values. For example, MMVI is 1000 + 1000 + 5 + 1 = 2006. Generally, symbols are placed in order of value, starting with the largest values. When smaller values precede larger values, the smaller values are subtracted from the larger values, and the result is added to the total. For example MCMXLIV = 1000 + (1000 − 100) + (50 − 10) + (5 − 1) = 1944.
The symbols “I”, “X”, “C”, and “M” can be repeated three times in succession, but no more. (They may appear four times if the third and fourth are separated by a smaller value, such as XXXIX.) “D”, “L”, and “V” can never be repeated.
“I” can be subtracted from “V” and “X” only. “X” can be subtracted from “L” and “C” only. “C” can be subtracted from “D” and “M” only. “V”, “L”, and “D” can never be subtracted.
Only one small-value symbol may be subtracted from any large-value symbol.
A number written in Arabic numerals can be broken into digits. For example, 1903 is composed of 1, 9, 0, and 3. To write the Roman numeral, each of the non-zero digits should be treated separately. In the above example, 1,000 = M, 900 = CM, and 3 = III. Therefore, 1903 = MCMIII.

Test input:
glob is I
prok is V
pish is X
tegj is L
glob glob Silver is 34 Credits
glob prok Gold is 57800 Credits
pish pish Iron is 3910 Credits
how much is pish tegj glob glob ?
how many Credits is glob prok Silver ?
how many Credits is glob prok Gold ?
how many Credits is glob prok Iron ?
how much wood could a woodchuck chuck if a woodchuck could chuck wood ?

Test Output:
pish tegj glob glob is 42
glob prok Silver is 68 Credits
glob prok Gold is 57800 Credits
glob prok Iron is 782 Credits
I have no idea what you are talking about

Instruções de execução: Para executar o programa, deve primeiro compilar o projeto MerchantsGuideToTheGalaxyApp e depois executar o arquivo MerchantsGuideToTheGalaxyApp.exe. Os dados de entrada se encontram no arquivo /Data/Input.txt. A saída é imprimida no console do programa.

Arquitetura:
A arquitetura do sistema é dividida em três partes principais: Converter, Input e Validator. Os converters são responsáveis por fazer a conversão de um tipo de numeral para outro. Atualmente foi implementado um conversor de números romanos para decimais (RomanNumeralToDecimalConverter.cs) e um conversor de unidades intergalacticas para decimais (IntergalacticCurrencyToCreditsConverter.cs). Os conversores são implementados a partir de conversores básicos:
- NumeralConverter: tipo de conversor mais básico. Possui apenas assinatura de um método de conversão
- NumeralConverterWithSymbolTable: conversor base que contém uma tabela de símbolos para tradução dos valores. Por exemplo, para o conversor de números romanos, a tabela de símbolo mapeia os símbolos I, V, X... para os valores 1, 5, 10...
- NumeralConverterWithSymbolTableAndMultiplierTable: conversor base que contém a tabela de símbolos e uma tabela de multiplicadores. Na moeda intergaláctica, por exemplo, um Silver vale 17 unidades. Por isso todo valor deve ser multiplicado pelo valor do multiplicador, quando existente.
Os conversores básicos recebem o tipo do valor do símbolo na tabela de símbolos (como generics) para ser mais genérico e poder ser reaproveitado em outros conversores. Isso é importante porque, no conversor de algarismos romanos o valor de cada símbolo pode ser dado em inteiro enquanto no conversor intergaláctico o valor do símbolo é dado através de outro símbolo.

Os validators são utilizados para validar uma entrada de numeral. Sua responsabilidade é informar se o numeral que está sendo passado como parâmetro para o converter é válido ou não

Os Inputs foram implementados de forma a serem estendidos. Cada classe implementa um tipo de entrada específico (criação da tabela de símbolos, pergunta, adição de multiplicador). O tipo InputSet agrupa diversos inputs agregando o comportamento de todos em um só objeto. Com a criação de um InputSet podemos criar um input que consiga processar entradas de criação da tabela de símbolos, pergunta e adição de multiplicador.

O conversor de unidades intergalácticas (IntergalacticCurrencyToCreditsConverter.cs) foi criado com base no conversor de algarismos romanos. Ele converte a entrada em algarismos romanos e delega a conversão para o conversor base.
