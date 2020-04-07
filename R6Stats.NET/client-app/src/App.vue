<template>
  <div id="app">
    <router-view />
  </div>
</template>

<style lang="scss">
#app {
  @import 'bootstrap/scss/bootstrap.scss';
  @import 'bootstrap-vue/src/index.scss';

  $body-bg: #000;
  $body-color: #111;
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
</style>
