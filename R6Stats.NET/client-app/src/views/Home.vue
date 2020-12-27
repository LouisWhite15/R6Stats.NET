<template>
  <div id="home">
    <!-- Header section -->
    <section>
      <navigation></navigation>
    </section>
    <b-container>
      <div>
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
    </b-container>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop, Provide, Watch } from "vue-property-decorator";
import Search from "../components/Search.vue";
import Results from "../components/Results.vue";
import Navigation from "../components/Navigation.vue";

// Import loading component and stylesheet
import Loading from 'vue-loading-overlay';
import 'vue-loading-overlay/dist/vue-loading.css';
Vue.use(Loading);

@Component({
  components: {
    Search,
    Results,
    Navigation
  }
})

export default class App extends Vue {
  @Provide() results:any = null;
  
  async onSearch(term:string) {
    const loader = this.$loading.show({
                  canCancel: false,
                  loader: 'dots',
                  isFullPage: true
                });
    
    const r6statsApi = Vue.axios.create();
    
    await r6statsApi
      .get(`${process.env.VUE_APP_R6STATS_API_BASE_URL}/r6stats/search/uplay/${term}`)
      .then((response) =>
      {
        this.results = response.data;
      })
      .catch(() =>
      {
        this.results = [];
      });
    
    loader.hide(); 
  }
}
</script>