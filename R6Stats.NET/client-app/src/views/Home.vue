<template>
  <div id="home">
    <div class="container" style="padding:30px">
      <div>
        <!-- Search section -->
        <section>
          <search @search="onSearch"></search>
        </section>
        <br/>
        <!-- Loading section -->
        <div class="d-flex justify-content-center mb-3" v-if="loading">
          <b-spinner type="grow" label="Loading..." v-for="spinner in [1,2,3]" :key=spinner></b-spinner>
        </div>
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
  @Prop() loading = false;
  
  async onSearch(term:string) {
    this.loading = true;
    this.results = [];
    await Vue.axios
      .get(`https://localhost:5001/r6stats/search/uplay/${term}`)
      .then((response) =>
      {
        this.loading=false;
        this.results = response.data;
      });
  }
}
</script>
