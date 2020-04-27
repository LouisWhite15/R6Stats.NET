<template>
  <div id="playerData">
    <div v-if="result.found === false">
      An error occured.
    </div>
    <br>
    <b-container> 
      <b-row class="bg-light" style="padding:10px">
        <b-col class="mx-auto"><img style="padding:10px" :src="'https://ubisoft-avatars.akamaized.net/' + result.player.id + '/default_256_256.png'" :alt="result.player.name + '\'s profile picture'" width="150" height="150"></b-col>
        <b-col class="my-auto" style="font-size: 20px; text-align:right;">NAME<br>LEVEL<br>LAST UPDATED</b-col>
        <b-col class="my-auto" style="font-size: 20px; text-align:left">{{result.player.name}}<br>{{result.stats.level}}<br>{{result.refresh.uTime | moment("calendar")}}</b-col>
        <b-col class="mx-auto"><img v-if="result.ranked.asiaRank != 0" :src="require('../assets/ranks/hd-rank' + result.ranked.asiaRank + '.svg')" :alt="result.ranked.asiaRankName + ' logo'" width="150" height="150"></b-col>
      </b-row>
      <br>
      <b-row>
        <b-col>
          <b-card
            title="Past Seasons Max Rank">
              <b-row>
                <!-- Insert rank history data here -->
                <b-row class="mx-auto"><br>Coming soon!</b-row>
              </b-row>
          </b-card>
        </b-col>
        <b-col>
          <b-card 
            title="Current Season"
            style="min-width: 100vh">
            <b-row class="bg-light title">
              <b-col>CURRENT MMR</b-col>
              <b-col>CURRENT RANK</b-col>
              <b-col>MAXIMUM MMR</b-col>
              <b-col>MAXIMUM RANK</b-col>
            </b-row>
            <b-row class="bg-light data">
              <b-col>{{result.ranked.asiaMmr}}</b-col>
              <b-col>{{result.ranked.asiaRankName}}</b-col>
              <b-col>{{result.ranked.asiaMaxMmr}}</b-col>
              <b-col>{{result.ranked.asiaMaxRankName}}</b-col>
            </b-row>
            <br>
            <b-row class="bg-light title">
              <b-col>KILLS</b-col>
              <b-col>DEATHS</b-col>
              <b-col>K/D</b-col>
            </b-row>
            <b-row class="bg-light data">
              <b-col>{{result.ranked.asiaKills}}</b-col>
              <b-col>{{result.ranked.asiaDeaths}}</b-col>
              <b-col>{{result.ranked.asiaKd}}</b-col>
            </b-row>
            <br>
            <b-row class="bg-light title">
              <b-col>WINS</b-col>
              <b-col>LOSSES</b-col>
              <b-col>W/L</b-col>
            </b-row>
            <b-row class="bg-light data" >
              <b-col>{{result.ranked.asiaWins}}</b-col>
              <b-col>{{result.ranked.asiaLosses}}</b-col>
              <b-col>{{result.ranked.asiaWinLossPercentage}}</b-col>
            </b-row>
            <br>
            <b-row class="bg-light title">
              <b-col>MMR CHANGE</b-col>
            </b-row>
            <b-row class="bg-light">
              <b-col><p v-if="result.ranked.asiaMmrChange > 0">+{{result.ranked.asiaMmrChange}}</p><p v-if="result.ranked.asiaMmrChange < 0">{{result.ranked.asiaMmrChange}}</p></b-col>
            </b-row>
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