<template>
  <div id="playerStats">
    <div id="nav" align="center">
      <router-link :to="{ name: 'Home' }"><br><img :src="require('../assets/r6stats_net_logo.png')" :alt="'R6Stats.NET logo'"><br></router-link>
    </div>
    <div v-if="result.found === false">
        An error occured.
    </div>
    <div id="playerData">
      <b-container> 
        <b-row class="bg-light" style="padding:10px">
          <b-col cols=1 class="mx-auto"><img style="padding:10px" :src="'https://ubisoft-avatars.akamaized.net/' + result.player.id + '/default_256_256.png'" :alt="result.player.name + '\'s profile picture'" width="150" height="150"></b-col>
          <b-col cols=3 class="my-auto" style="font-size: 20px; text-align:right;">NAME<br>LEVEL<br>LAST UPDATED</b-col>
          <b-col cols=3 class="my-auto" style="font-size: 20px; text-align:left">{{result.player.name}}<br>{{result.stats.level}}<br>{{result.refresh.uTime | moment("calendar")}}</b-col>
          <b-col cols=1 class="mx-auto"><img :src="require('../assets/ranks/hd-rank' + result.ranked.rank + '.svg')" :alt="result.ranked.rankName + ' logo'" width="150" height="150"></b-col>
        </b-row>
        <br>
        <b-row>
          <b-col cols=3>
            <pastSeasonsMaxRank :data="result"></pastSeasonsMaxRank>
          </b-col>
          <b-col cols=9>
            <currentSeason :data="result"></currentSeason>
            <br>
            <matchHistory :data="result"></matchHistory>
          </b-col>
        </b-row>
      </b-container>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop, Provide } from "vue-property-decorator";
import CurrentSeason from "../components/CurrentSeason.vue";
import MatchHistory from "../components/MatchHistory.vue";
import PastSeasonsMaxRank from "../components/PastSeasonsMaxRank.vue";

// Import loading component and stylesheet
import Loading from 'vue-loading-overlay';
import 'vue-loading-overlay/dist/vue-loading.css';
Vue.use(Loading);

@Component({
  components: {
    CurrentSeason,
    MatchHistory,
    PastSeasonsMaxRank
  }
})

export default class PlayerStats extends Vue {
  @Provide() result = [];
  
  async created() {
    const loader = this.$loading.show({
                  canCancel: false,
                  loader: 'dots',
                  isFullPage: true
                });
    
    this.result = [];
    
    const r6statsApi = Vue.axios.create();

    // Update player stats on load
    await r6statsApi
      .get(`${process.env.VUE_APP_R6STATS_API_BASE_URL}/r6stats/update/${this.$route.params.id}`);

    // Retrieve player stats
    await r6statsApi
      .get(`${process.env.VUE_APP_R6STATS_API_BASE_URL}/r6stats/player/${this.$route.params.id}`)
      .then((response) =>
      {
        this.result = response.data;
      });
    
     loader.hide();
  }
}
</script>