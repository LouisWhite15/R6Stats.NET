<template>
  <div id="playerData">
    <div v-if="result.found === false">
      An error occured.
    </div>
    <br>
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
          <b-card
            title="Past Seasons Max Rank">
                <b-row v-for="item in seasonsData" :key="item" class="mx-auto">
                  <b-col class="h6 my-auto">{{item.seasonName}}</b-col>
                  <b-col class="my-auto mx-auto">
                      <img :src="require('../assets/ranks/hd-rank' + item.maxRank + '.svg')" :alt="item.maxRankName + ' logo'" width="50" height="50">
                      <p v-if="item.maxMmr !== null">{{item.maxMmr}}</p><p v-if="item.maxMmr === null">Unranked</p>
                  </b-col>
                </b-row>
          </b-card>
        </b-col>
        <b-col cols=9>
          <b-card 
            title="Current Season">
            <b-row class="bg-light title">
              <b-col>CURRENT MMR</b-col>
              <b-col>CURRENT RANK</b-col>
              <b-col>MAXIMUM MMR</b-col>
              <b-col>MAXIMUM RANK</b-col>
            </b-row>
            <b-row class="bg-light data">
              <b-col class="my-auto">{{result.ranked.mmr}}</b-col>
              <b-col><img :src="require('../assets/ranks/hd-rank' + result.ranked.rank + '.svg')" :alt="result.ranked.rankName + ' logo'" width="50" height="50"></b-col>
              <b-col class="my-auto">{{result.ranked.maxMmr}}</b-col>
              <b-col><img :src="require('../assets/ranks/hd-rank' + result.ranked.maxRank + '.svg')" :alt="result.ranked.maxRankName + ' logo'" width="50" height="50"></b-col>
            </b-row>
            <br>
            <b-row class="bg-light title">
              <b-col>KILLS</b-col>
              <b-col>DEATHS</b-col>
              <b-col>K/D</b-col>
            </b-row>
            <b-row class="bg-light data">
              <b-col>{{result.ranked.kills}}</b-col>
              <b-col>{{result.ranked.deaths}}</b-col>
              <b-col>{{result.ranked.kd}}</b-col>
            </b-row>
            <br>
            <b-row class="bg-light title">
              <b-col>WINS</b-col>
              <b-col>LOSSES</b-col>
              <b-col>W/L</b-col>
            </b-row>
            <b-row class="bg-light data" >
              <b-col>{{result.ranked.wins}}</b-col>
              <b-col>{{result.ranked.losses}}</b-col>
              <b-col>{{result.ranked.winLossPercentage}}</b-col>
            </b-row>
            <br>
            <b-row class="bg-light title">
              <b-col>MMR CHANGE</b-col>
            </b-row>
            <b-row class="bg-light">
              <b-col><p style="color: green" v-if="result.ranked.mmrChange > 0">+{{result.ranked.mmrChange}}</p><p style="color: red" v-if="result.ranked.mmrChange < 0">{{result.ranked.mmrChange}}</p></b-col>
            </b-row>
          </b-card>
          <br>
          <b-card
            title="Match History">
            <b-container v-for="item in matchHistory" :key="item" class="mx-auto">
              <b-row class="bg-light title">
                <b-col style="font-size: 20px">{{item.date}}</b-col>
              </b-row>
              <b-row class="bg-light title">
                <b-col>MATCHES</b-col>
                <b-col>WINS</b-col>
                <b-col>LOSSES</b-col>
              </b-row>
              <b-row class="bg-light data">
                <b-col>{{item.rankedMatches}}</b-col>
                <b-col>{{item.rankedWins}}</b-col>
                <b-col>{{item.rankedLosses}}</b-col>
              </b-row>
              <b-row class="bg-light title">
                <b-col>KILLS</b-col>
                <b-col>DEATHS</b-col>
                <b-col>K/D</b-col>
                <b-col>HEADSHOT %</b-col>
              </b-row>
              <b-row class="bg-light data">
                <b-col>{{item.rankedKills}}</b-col>
                <b-col>{{item.rankedDeaths}}</b-col>
                <b-col>{{item.rankedKd}}</b-col>
                <b-col>{{item.headshotAccuracy}}</b-col>
              </b-row>
              <b-row class="bg-light title">
                <b-col>MMR CHANGE</b-col>
              </b-row>
              <b-row class="bg-light data">
                <b-col><p style="color: green" v-if="item.asiaMmrChange > 0">+{{item.asiaMmrChange}}</p><p style="color: red" v-if="item.asiaMmrChange < 0">{{item.asiaMmrChange}}</p><p v-if="item.asiaMmrChange == 0">{{item.asiaMmrChange}}</p></b-col>
              </b-row>
              <br>
            </b-container>
          </b-card>
        </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'

@Component
export default class PlayerData extends Vue {
  @Prop() data:any;

  get result() {
    return this.data;
  }

  get seasonsData() {
    return Object.values(this.data.seasons).reverse();
  }

  get matchHistory() {
    return Object.values(this.data.matchHistory).slice(0, 5);
  }
}
</script>

<style lang="scss">
.title{
  font-weight: bold;
  padding-top: 10px;
}

.data{
  padding-bottom: 10px;
}
</style>