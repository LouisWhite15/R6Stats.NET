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
import { Component, Vue, Prop, Provide, Watch } from "vue-property-decorator";
import Search from "../components/Search.vue";
import Results from "../components/Results.vue";

// Import loading component and stylesheet
import Loading from 'vue-loading-overlay';
import 'vue-loading-overlay/dist/vue-loading.css';
Vue.use(Loading);

@Component({
  components: {
    Search,
    Results
  }
})

export default class App extends Vue {
  @Provide() results = [];
  
  async onSearch(term:string) {
    const loader = this.$loading.show({
                  canCancel: false,
                  loader: 'dots',
                  isFullPage: true
                });
    
    this.results = [];
    
    const r6statsApi = Vue.axios.create();
    
    await r6statsApi
      .get(`${process.env.VUE_APP_R6STATS_API_BASE_URL}/r6stats/search/uplay/${term}`)
      .then((response) =>
      {
        this.results = response.data;
      });
    
    loader.hide(); 
  }
}
</script>