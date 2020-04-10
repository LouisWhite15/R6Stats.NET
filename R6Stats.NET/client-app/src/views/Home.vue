<template>
  <div id="home">
    <div class="container" style="padding:30px">
      <div>
        <!-- Header section -->
        <section>
          <router-link :to="{ name: 'Home' }"><h1 style="padding:30px">R6Stats.NET</h1></router-link>
        </section>
        <!-- Search section -->
        <section>
          <search @search="onSearch"></search>
        </section>
        <br>
        <!-- Results section -->
        <section>
          <results :data="results"></results>
        </section>
      </div>
     </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop, Provide } from "vue-property-decorator";
import Search from "../components/Search.vue";
import Results from "../components/Results.vue";

@Component({
  components: {
    Search,
    Results
  }
})

export default class App extends Vue {
  @Provide() results = [];
  
  async onSearch(term:string) {
    this.results = [];
    await Vue.axios
      .get(`https://localhost:5001/r6stats/search/uplay/${term}`)
      .then((response) =>
      {
        this.results = response.data;
      });
  }
}
</script>
