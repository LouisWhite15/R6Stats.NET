<template>
  <div id="home">
    <h1>R6Stats.NET</h1>
    <div class="container-fluid">
      <div class="row mx-auto">
        <!-- Search section -->
        <section class="col-sm-12 pt-3 px-0">
          <search @search=onSearch></search>
        </section>
        <!-- Results section -->
        <section class="results">
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
    await Vue.axios.get(`https://localhost:5001/r6stats/player/uplay/${term}`).then((response) =>
    {
      this.results = response.data;
    })
  }
}
</script>
