<script setup lang="ts">
import WelcomeItem from './WelcomeItem.vue'
import AppIcon from './icons/IconApp.vue'
import TimeIcon from './icons/IconTime.vue'
import EcosystemIcon from './icons/IconEcosystem.vue'
import CommunityIcon from './icons/IconCommunity.vue'
import CheckIcon from './icons/IconCheck.vue'
</script>

<template>
  <WelcomeItem>
    <template #icon>
      <AppIcon />
    </template>
    <template #heading>PrediLang</template>

    Aplicação desenvolvida com o objetivo de servir como validação de conceito para o artigo 'Uma
    Ferramenta de Apoio a Estudos de Futuro Utilizando Linguagem Natural', escrito pelo mestrando
    Alan Felipe de Lima Neres, sob a orientação do professor Dr. Edilson Feneda.
  </WelcomeItem>

  <WelcomeItem>
    <template #icon>
      <TimeIcon />
    </template>
    <template #heading>Estudo de Futuros</template>

    A aplicação utiliza técnicas avançadas de Processamento de Linguagem Natural (PLN) para conduzir
    estudos de futuros, que são metodologias voltadas para a análise e previsão de possíveis
    cenários futuros.
  </WelcomeItem>

  <WelcomeItem>
    <template #icon>
      <EcosystemIcon />
    </template>
    <template #heading>Criação de Cenários</template>

    A criação de cenários é um componente essencial para a previsão e planejamento estratégico,
    permitindo que os usuários explorem diferentes possibilidades e preparem-se para diversas
    eventualidades.
  </WelcomeItem>

  <WelcomeItem>
    <template #icon>
      <CommunityIcon />
    </template>
    <template #heading>Processamento de Linguagem Natural</template>

    O Processamento de Linguagem Natural (PLN) é a base tecnológica da aplicação. Utilizando
    técnicas avançadas de PLN, a aplicação transforma dados brutos em insights acionáveis, que são
    essenciais para os estudos de futuros e a criação de cenários.
  </WelcomeItem>

  <WelcomeItem>
    <template #icon>
      <CheckIcon />
    </template>
    <template #heading>Acesse a Aplicação</template>

    <a href="https://vuejs.org/sponsor/" target="_blank" rel="noopener">Clique aqui</a> para acessar
    a aplicação e receber insights futuros de forma descomplicada.
  </WelcomeItem>
</template>
