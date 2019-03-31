﻿using Gympass_Interview.Entities;
using Gympass_Interview.Extrators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gympass_Interview.Services
{
    public class KartRaceInformation
    {
        public List<KartLap> Laps { get; set; }
        public List<KartRaceResult> Ranking { get; set; }
        public KartRaceResult BestLap { get; set; }

        public IExtractKartRaceFileService ExtractService { get; set; }
        public IComputeRankingKartRaceService ComputeService { get; set; }
        public IOutputKartRaceInformationService OutputService { get; set; }

        public KartRaceInformation(
            IExtractKartRaceFileService extractService, 
            IComputeRankingKartRaceService computeService,
            IOutputKartRaceInformationService outputService
            )
        {
            this.ExtractService = extractService;
            this.ComputeService = computeService;
            this.OutputService = outputService;
        }

        public List<KartLap> ExtractDataFromFile(string filePath)
        {
            this.Laps = this.ExtractService.ExtractDataFromFile(filePath);
            return this.Laps;
        }

        public List<KartRaceResult> ComputeRanking()
        {
            this.Ranking = this.ComputeService.ComputeRanking(this.Laps);
            return this.Ranking;
        }

        public KartRaceResult GetBestLap()
        {
            this.BestLap = this.ComputeService.GetBestLap();
            return this.BestLap;
        }

        public void PrintOutput()
        {
            this.OutputService.PrintLapsLog(this.Laps);
            this.OutputService.PrintRanking(this.Ranking);
            this.OutputService.PrintBestLapInfo(this.BestLap);
        }
    }
}
