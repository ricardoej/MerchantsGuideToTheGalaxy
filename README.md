MerchantsGuideToTheGalaxy
=========================
Instruções de execução: Para executar o programa, deve primeiro compilar o projeto MerchantsGuideToTheGalaxyApp e depois executar o arquivo MerchantsGuideToTheGalaxyApp.exe. Os dados de entrada se encontram no arquivo /Data/Input.txt. Saída é imprimida no console do programa.

Arquitetura:
A arquitetura do sistema é dividida em três partes principais: Converter, Input e Validator. Os converters são responsáveis por fazer a conversão de um tipo de numeral para outro. Atualmente foi implementado um conversor de números romanos para decimais (RomanNumeralToDecimalConverter.cs) e um conversor de unidades intergalacticas para decimais (IntergalacticCurrencyToCreditsConverter.cs). Os conversores são implementados a partir de conversores básicos:
- NumeralConverter: tipo de conversor mais básico. Possui apenas assinatura de um método de conversão
- NumeralConverterWithSymbolTable: conversor base que contém uma tabela de símbolos para tradução dos valores. Por exemplo, para o conversor de números romanos, a tabela de símbolo mapeia os símbolos I, V, X... para os valores 1, 5, 10...
- NumeralConverterWithSymbolTableAndMultiplierTable: conversor base que contém a tabela de símbolos e uma tabela de multiplicadores. Na moeda intergaláctica, por exemplo, um Silver vale 17 unidades. Por isso todo valor deve ser multiplicado pelo valor do multiplicador, quando existente.
Os conversores básicos recebem o tipo do valor do símbolo na tabela de símbolos (como generics) para ser mais genérico e poder ser reaproveitado em outros conversores. Isso é importante porque, no conversor de algarismos romanos o valor de cada símbolo pode ser dado em inteiro enquanto no conversor intergaláctico o valor do símbolo é dado através de outro símbolo.

Os validator são utilizados para validar uma entrada de numeral. Sua responsabilidade é informar se o numeral que está sendo passado como parâmetro para o converter é válido ou não

Os Inputs foram implementados de forma a serem estendidos. Cada classe implementa um tipo de entrada específico (criação da tabela de símbolos, pergunta, adição de multiplicador). O tipo InputSet agrupa diversos inputs agregando o comportamento de todos em um só objeto. Com a criação de um InputSet podemos criar um input que consiga processar entradas de criação da tabela de símbolos, pergunta e adição de multiplicador.

O conversor de unidades intergalácticas (IntergalacticCurrencyToCreditsConverter.cs) foi criado com base no conversor de algarismos romanos. Ele converte a entrada em algarismos romanos e delega a conversão para o conversor base.
