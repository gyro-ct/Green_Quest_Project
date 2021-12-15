# Green_Quest_Project

Green Quest é um jogo sério feito por alunos do Laboratório de Avaliação da Sustentabilidade do Ciclo de Vida (Gyro), da Universidade Tecnológica Federal do Paraná (UTFPR - Câmpus Curitiba) para a disciplina de Gestão Ambiental dos cursos de Engenharia Mecânica e Engenharia Mecatrônica. Ele está vinculado ao projeto PanGEA de desenvolvimento de ferramentas de apoio à disciplina por gamificação, vídeos e atividades.

## Rodando o jogo

Para rodar o jogo pela primeira vez, extraia a pasta ```Build``` para o seu computador e abra ela. Dentro do diretório ´`´Green Quest´´` haverá o arquivo ```Green Quest.exe```, abra este arquivo para rodar o jogo.

## Estrutura de pastas

O jogo foi feito na plataforma Unity (versão 2020.2.7f1) em linguagem C# com a utilização das seguintes libraries:

- 2D Entities (0.32.0-preview.5)
- 2D Sprite (1.0.0)
- 2D SpriteShape (5.1.3)
- 2D Tilemap Editor (1.0.0)
- JetBrains Rider Editor (2.0.7)
- Post Processing (3.0.3)
- Test Framework (1.1.22)
- TextMeshPro (3.0.1)
- Timline (1.4.6)
- Unity Collaborate (1.3.9)
- Unity UI (1.0.0)
- Universar RP (10.3.2)
- Visual Studio Code Editor (1.2.3)
- Visual Studio Editor (2.0.7)
- Json.NET for Unity (13.0.102)
- Json.NET Converters of Unity types (1.3.0)
- PlayFab (SDK 2.106.210406) - Responsável pelo manejo de logins no jogo
- Dialogue Editor (1.1.02) - Responsável pelas conversas e sua interface no jogo

Green Quest foi feito para ser um jogo introdutório aos assuntos de sustentabilidade e gerenciamento ambiental e está finalizado para jogar apenas para um número limitado de quests referentes à primeira aula devido ao curto tempo de projeto. Maiores informações técnicas podem ser vistas no arquivo de ([Game Design Development](https://github.com/gyro-ct/Green_Quest_Project/blob/main/19122020_Game%20Design%20Document%20(GDD).docx))

## Estrutura de pastas e arquivos

O projeto segue a estruturação básica de um projeto Unity, sendo a pasta ```Assets``` a que apresenta as imagens, vídeos, audios, códigos-fonte, cenas e outros elementos do design do jogo.

O jogo é dividido em vários cenários adaptados em diferentes cenas. Estas cenas estão na pasta ```Assets/Scenes```. Estas cenas são compostas pelos objetos adicionados (como o objeto do personagem, NPCs, interfaces presentes) e seus respectivos códigos-fonte. As cenas utilizadas no jogo (que não são exclusivas para prototipagem durante o desenvolvimento do jogo) foram:

- LoginScene: Interface de login para o jogo
- BedroomScene: Quarto do personagem
- LivingRoomScene: Sala da casa do personagem
- CityScene: Cidade do jogo
- CompanyReceptionScene: Recepção da empresa que o jogador é contratado no jogo
- Corredor: Corredor com acesso às diferentes áreas da empresa. É uma cena intermediária que liga as entradas para diferentes áreas do jogo
- CompanyBathroom: Cena do banheiro da empresa
- CompanyCoffeeScene: Cena da área do cafezinho na empresa 
- CompanyComprasScene: Cena da área de compras na empresa
- CompanyComunicacaoMarketingScene: Cena da área de comunicação e marketing na empresa
- CompanyGardenOutsideScene: Cena da área externa da empresa
- CompanyLawScene: Cena da área jurídica da empresa
- CompanyLogisticScene: Cena da área logística da empresa
- CompanyMaintenanceScene: Cena da área de manutenção e almoxarifado da empresa
- CompanyProductionScene: Cena da área de produção da empresa
- CompanySGARoom: Cena da área de SGA da empresa
- DireçãoScene: Cena da área de direção da empresa

Os objetos pré-fabricados (um arquivo blueprint de um objeto padrão do jogo que pode ser modificado), ou 'prefabs' se encontram na pasta ```Assets/Prefabs```. Estes arquivos compreendem objetos com informações que devem ser mantidas durante as mudanças de cena como objetos de NPCs, de interface como menus e botões (que carregam os códigos-fonte de gerenciamento) e objetos que tem instanciamento (são únicos) durante a jogabilidade. Para melhor visualização destes, recomenda-se abrir o projeto na plataforma Unity e procurar por objetos azuis na aba de hierarquia da cena.

As animações dos personagens e outros objetos no jogo estão todas na pasta ```Assets/Animation```. A maior parte dos arquivos é utilizada para animar a interface do HUD, do tablet, do inventário (mochila) e menus ou painéis do jogo, exceto pelos arquivos que iniciam com "Player_" (animação de movimento e ações do player), com "Eva" ou com enxerto "_Eva_" (animação de movimento e ações do NPC Eva) e "Emp_" (animação de movimento da empilhadeira da quest da área de logística). 

Na raiz da pasta ```Assets```, na pasta ```Assets/Scripts``` e nas pastas respecitivas dos presets do jogo ```Assets/Prefabs``` são encontrados os códigos-fonte em C# utilizados nos objetos do jogo. Os arquivos foram majoritariamente nomeados de forma a facilitar sua localização nos objetos do jogo e tem maiores detalhes comentados em seu conteúdo. Os arquivos marcados com o final "Manager" são códigos mais gerais e que controlam as funções de gerenciamento mais básicas dos seus respectivos temas. Estes arquivos são:

- ConversationManager2: controla conversas específicas que precisam de layout diferente
- EmailManager: controla o recebimento de mensagens de email pelo tablet no jogo
- ItemManager: controla os itens do inventário do jogo
- NoticiaManager: controla o recebimento de notícias pelo tablet no jogo
- PortaManager: controla a ativação e desativação de portas no jogo
- ProgressBarManager: controla as barras de progresso de experiencia e stamina no jogo
- Q101QuizManager: controla especificamente as perguntas e pontuação da primeira quest do jogo
- CompComprasManager: controla especificamente as escolhas e resultados da missão da área comercial do jogo
- ComputerUIManager: controla o computador da primeira quest do jogo
- ConvManager: controla as conversas realizadas no jogo
- PlayFabManager: controla o login do jogo a partir da biblioteca "PlayFab"
- QuestManager: controla as quests do jogo, sua atribuição, estágio e se está ou não completa
- QuestUIManager: controla a interface de quests, como são apresentadas e suas opções no jogo

Os arquivos com final "Controller" são responsáveis pelo gerenciamento do personagem principal e outros NPCs do jogo, sues movimentos, missões específicas e controle da situação do personagem para save/load. Estes arquivos são:

- ArahController: controle do NPC da da diretora área de manufatura
- BrenesController: controle do NPC do diretor da área jurídica
- DiretorInstance: controle do NPC do diretor da empresa
- EvaController: controle do NPC mentor da área de SGA
- KanoController: controle do NPC do diretor da área da almoxarifado e manutenção
- NebeliController: controle do NPC da diretora da área de logística
- NibilaController: controle do NPC principal da área de marketing (este controller é responsável pelas missões na área de marketing)
- PersulaController: controle do NPC da diretora da área comercial
- SrNexusSemiController: controle do NPC do diretor da área de marketing
- Mother: controle do NPC da mãe do personagem
- PlayerController: controle principal dos movimentos e ações do personagem jogável (principal)

Vários arquivos de código-fonte são responsáveis pelo funcionamento da interface (UI) do jogo, como botões, inputs de texto, listas, painéis e outros... Estes arquivos são:

- ButtonFornecedorCompras, InfoPainel, OpenSavePanel, BotaoTrocarTela, CountDownTimer, ButtonSlot, Computador, Inventory, ProgressBar, SettingsMenu, TutorialGame, UIConversationButton2, UIFade (Miscelaneous)
- UseButton
- ContatosButton
- LigarButton
- EmailButton
- QLogButton
- NoticiaButton
- QuestProvisoryPanel: responsável pelo painel de quests em forma de pop-up e sua interação com o gerenciador de quests
- MyCamera: responsável pelo controle do movimento da câmera
- HUD: responsável pelo 'heads-up screen' que mostra informações do personagem na tela do jogo

Códigos de mudança de cena durante o jogo foram adicionados para que fosse possível modificar certos ambientes e carregar os elementos principais do arquivo "EssentialsLoader.cs". Estes arquivos são:

- AreaEntrance: Ativado ao entrar em uma nova cena
- AreaExit: Ativado ao sair de uma cena, responsável por chamar a paróxima cena

Os códigos responsáveis pelo gerenciamento do save, do load e do quit no jogo são:

- Save
- SaveLoadQuitGame

Outros arquivos não listados acima correspondem à classes de objetos, códigos de colisão entre objetos, funções específicas de objetos, ativação de objetos e conversas e códigos adicionais.

Os arquivos de audio (audio também se encontra em ```Assets/Audio```, imagens, tilesets e outros elementos de design utilizados para compor o visual do jogo podem ser encontrados na pasta ```Assets/Art```. Para melhor entendimento do seu uso no jogo, recomenda-se abrir o projeto na Unity e procurar os itens a partir da hierarquia das cenas.
