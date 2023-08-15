<template>
  <NavBar />
  <main>
    <slot />
  </main>
  <Footer />
</template>

<script setup>

import NavBar from "@/Components/NavBar.vue";
import Footer from "@/Components/Footer.vue";
</script>
