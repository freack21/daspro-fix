<template>
  <v-app>
    <div id="app">
      <img src="./assets/logo-unri2.png" width="300px" height="45px" style="margin:8px 2px;">
      <web-toolbar></web-toolbar>
      <router-view/>
      <web-footer></web-footer>
    </div>
  </v-app>
</template>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: left;
  color: #2c3e50;
}

</style>

<script>
import WebToolbar from './components/WebToolbar'
import WebFooter from './components/WebFooter';

export default {
  name: 'App',
  components: {WebFooter,WebToolbar}
  }
</script>