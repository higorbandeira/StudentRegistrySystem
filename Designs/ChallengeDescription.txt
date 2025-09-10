Especificação do Sistema de Cadastro de Alunos (Atualizada)

-> Objetivo

Desenvolver um sistema de cadastro de alunos para o ensino fundamental e médio, garantindo que as regras de idade, tutoria legal e comunicação com os responsáveis sejam respeitadas. O sistema deve permitir o acompanhamento do cadastro pelos tutores legais e oferecer uma interface amigável para a gestão escolar.

-> Requisitos Funcionais

-> Cadastro de Alunos
O sistema deve permitir o cadastro de alunos com as seguintes informações obrigatórias:
Nome completo
Data de nascimento
Ano letivo pretendido
Nome(s) do(s) tutor(es) legal(is)
Contato do(s) tutor(es) legal(is) (WhatsApp, e-mail e telefone para SMS)
O sistema deve validar a idade do aluno com base no ano letivo pretendido:
Ensino Fundamental:
1º ano: 6 anos completos até o início do ano letivo.
2º ano: 7 anos completos até o início do ano letivo.
...
9º ano: 14 anos completos até o início do ano letivo.
Ensino Médio:
1º ano: 15 anos completos até o início do ano letivo.
2º ano: 16 anos completos até o início do ano letivo.
3º ano: 17 anos completos até o início do ano letivo.
Caso a idade do aluno não esteja de acordo com o ano letivo pretendido, o sistema deve:
Bloquear o cadastro do aluno.
Gerar uma notificação para a diretoria escolar solicitando aprovação manual.
Enviar uma notificação aos tutores legais informando sobre a necessidade de aprovação.
O sistema deve garantir que o aluno tenha menos de 18 anos no momento do cadastro, exceto se ele tiver completado 18 anos após julho do ano letivo.

-> Cadastro de Tutores Legais
O sistema deve permitir o cadastro de até dois tutores legais por aluno.
Para cada tutor, devem ser cadastradas as seguintes informações:
Nome completo
CPF
Contato (WhatsApp, e-mail e telefone para SMS)
O sistema deve validar a existência de pelo menos um tutor legal para cada aluno.
Notificações e Comunicação

-> O sistema deve enviar notificações automáticas aos tutores legais sobre a situação cadastral do aluno, utilizando os seguintes canais:
WhatsApp (simulado)
E-mail (simulado)
SMS (simulado)
As notificações devem incluir:
Status do cadastro (aprovado, pendente, rejeitado).
Motivo da pendência ou rejeição, se aplicável.
Orientações para regularizar o cadastro, se necessário.
As notificações simuladas devem ser armazenadas no banco de dados para consulta posterior.

-> Portal de Acompanhamento para Tutores

O sistema deve disponibilizar um portal online para os tutores legais, onde eles possam:
Consultar o status do cadastro do aluno.
Atualizar informações de contato.
Visualizar notificações enviadas pelo sistema.
Consultar documentos ou solicitações pendentes.
O acesso ao portal deve ser protegido por autenticação simples (não é necessário autenticação forte) e vinculado ao CPF do tutor legal.

-> Requisitos Não Funcionais

- Segurança:
O sistema deve garantir a proteção dos dados pessoais dos alunos e tutores, em conformidade com a LGPD (Lei Geral de Proteção de Dados).
A autenticação deve ser simples, mas suficiente para proteger o acesso ao portal.
Usabilidade:
A interface do sistema deve ser intuitiva e acessível para usuários com diferentes níveis de familiaridade com tecnologia.
Escalabilidade:
O sistema deve ser capaz de suportar o cadastro de até 10.000 alunos simultaneamente.
Disponibilidade:
O sistema deve estar disponível 99,9% do tempo, com exceção de períodos programados para manutenção.
Integração:
O sistema deve ser capaz de integrar-se com serviços de envio de mensagens (WhatsApp, e-mail e SMS) e com sistemas internos da escola, como o sistema de gestão acadêmica.
Documentação:
Deve ser gerada uma documentação detalhada explicando como executar o sistema em ambiente local.

- Tecnologias
Backend:
ASP.NET Core para a lógica de negócios.
Banco de Dados:
PostgreSQL com Entity Framework Core (EF Core) para mapeamento objeto-relacional.
Notificações:
Simulação de envio de notificações (WhatsApp, e-mail e SMS), com armazenamento no banco de dados para consulta posterior.
Mensageria:
RabbitMQ para gerenciamento de filas de mensagens.
Hospedagem:
O sistema deve ser configurado para execução em contêineres Docker.
Orquestração:
Docker Compose para configuração e execução de dependências (RabbitMQ, banco de dados, etc.).

- Entrega e Configuração
Docker Compose:
Deve ser gerado um arquivo docker-compose.yml para configurar e baixar todas as dependências necessárias (RabbitMQ, PostgreSQL, etc.).
Documentação:
Deve ser gerada uma documentação detalhada explicando como executar o sistema em ambiente local, incluindo:
Passos para configurar o ambiente.
Comandos para iniciar o sistema.
Detalhes sobre as dependências utilizadas.
Critérios de Avaliação

-> Estrutura do Projeto
Estrutura Arquitetural:
O projeto deve seguir uma arquitetura bem definida, como:
Clean Architecture
Hexagonal Architecture
Vertical Slice Architecture
Padrões de Projeto:
O uso de padrões de projeto será avaliado, como:
Repository Pattern
Factory Pattern
Dependency Injection
SOLID:
O código deve seguir os princípios SOLID para garantir manutenibilidade e extensibilidade.
Clean Code:
O código deve ser limpo, legível e bem documentado.

- Testes
Estrutura dos Testes:
O projeto deve conter uma estrutura clara para testes unitários e de integração.
Cobertura de Testes:
A completude dos testes será avaliada, garantindo que os principais fluxos do sistema estejam cobertos.
Automação:
Sempre que possível, os testes devem ser automatizados.

-> Funcionalidades

O sistema deve impedir o cadastro de alunos que não atendam aos critérios de idade, salvo aprovação manual da diretoria.
O sistema deve enviar notificações automáticas aos tutores legais em tempo real (simulado).
O portal de acompanhamento deve ser acessível e funcional para os tutores legais.
O sistema deve garantir a integridade e segurança dos dados cadastrados.
Essa especificação foi complementada com as tecnologias e critérios de avaliação solicitados. Caso haja necessidade de ajustes ou adições, favor informar.