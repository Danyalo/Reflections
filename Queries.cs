using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data;

namespace Reflections
{


    class Queries
    {

        //Житель
        public static Citizen GetCitizen(int CitizenID)
        {
            var Citizen = new Citizen();

            using (ElectionContext db = new ElectionContext())
            {
                Citizen = db.Citizen.Where(e => e.CitizenId == CitizenID).First();
            }

            return Citizen;
        }

        public static void AddCitizen(Citizen Citizen)
        {
            using (ElectionContext db = new ElectionContext())
            {
                db.Citizen.Add(Citizen);
                db.SaveChanges();
            }
        }

        public static void UpdateCitizen(Citizen Citizen)
        {
            using (ElectionContext db = new ElectionContext())
            {
                var dbCitizen = db.Citizen.Where(e => e.CitizenId == Citizen.CitizenId).First();
                if (dbCitizen != null)
                {
                    dbCitizen = Citizen;
                }
                db.SaveChanges();
            }
        }

        public static void DeleteCitizen(Citizen Citizen)
        {
            using (ElectionContext db = new ElectionContext())
            {
                db.Citizen.Remove(Citizen);
                db.SaveChanges();
            }
        }


        //////////Адміністратор
        //додати, змiнити чи видалити вибори;
        //database.Add(election);          
        //database.Remove(election);            
        //var id = 1;
        //var election = database.First(e => e.election_id == id);

        public static Election GetElection(int electionID)
        {
            var election = new Election();

            using (ElectionContext db = new ElectionContext())
            {
                election = db.Election.Where(e => e.ElectionId == electionID).First();
            }

            return election;
        }

        public static void AddElection(Election election)
        {
            using (ElectionContext db = new ElectionContext())
            {
                db.Election.Add(election);
                db.SaveChanges();
            }
        }

        public static void UpdateElection(Election election)
        {
            using (ElectionContext db = new ElectionContext())
            {
                var dbElection = db.Election.Where(e => e.ElectionId == election.ElectionId).First();
                if (dbElection != null)
                {
                    dbElection = election;
                }
                db.SaveChanges();
            }
        }

        public static void DeleteElection(Election election)
        {
            using (ElectionContext db = new ElectionContext())
            {
                db.Election.Remove(election);
                db.SaveChanges();
            }
        }


        //додати, змiнити чи видалити вiртуальний округ;
        //database.Add(virtual_region);
        //database.Remove(virtual_region);
        //var id = 1;
        //var virtual_region = database.First(e => e.virtual_region_id == id);

        public static VirtualRegion GetVirtualRegion(int VirtualRegionID)
        {
            var VirtualRegion = new VirtualRegion();

            using (ElectionContext db = new ElectionContext())
            {
                VirtualRegion = db.VirtualRegion.Where(e => e.VirtualRegionId == VirtualRegionID).First();
            }

            return VirtualRegion;
        }

        public static void AddVirtualRegion(VirtualRegion VirtualRegion)
        {
            using (ElectionContext db = new ElectionContext())
            {
                db.VirtualRegion.Add(VirtualRegion);
                db.SaveChanges();
            }
        }

        public static void UpdateVirtualRegion(VirtualRegion VirtualRegion)
        {
            using (ElectionContext db = new ElectionContext())
            {
                var dbVirtualRegion = db.VirtualRegion.Where(e => e.VirtualRegionId == VirtualRegion.VirtualRegionId).First();
                if (dbVirtualRegion != null)
                {
                    dbVirtualRegion = VirtualRegion;
                }
                db.SaveChanges();
            }
        }

        public static void DeleteVirtualRegion(VirtualRegion VirtualRegion)
        {
            using (ElectionContext db = new ElectionContext())
            {
                db.VirtualRegion.Remove(VirtualRegion);
                db.SaveChanges();
            }
        }


        //додати, змiнити чи видалити вiртуальну дiльницю;    
        //database.Add(virtual_house);
        //database.Remove(virtual_house);
        //var id = 1;
        //var virtual_house = database.First(e => e.virtual_house_id == id);

        public static VirtualHouse GetVirtualHouse(int VirtualHouseID)
        {
            var VirtualHouse = new VirtualHouse();

            using (ElectionContext db = new ElectionContext())
            {
                VirtualHouse = db.VirtualHouse.Where(e => e.VirtualHouseId == VirtualHouseID).First();
            }

            return VirtualHouse;
        }

        public static void AddVirtualHouse(VirtualHouse VirtualHouse)
        {
            using (ElectionContext db = new ElectionContext())
            {
                db.VirtualHouse.Add(VirtualHouse);
                db.SaveChanges();
            }
        }

        public static void UpdateVirtualHouse(VirtualHouse VirtualHouse)
        {
            using (ElectionContext db = new ElectionContext())
            {
                var dbVirtualHouse = db.VirtualHouse.Where(e => e.VirtualHouseId == VirtualHouse.VirtualHouseId).First();
                if (dbVirtualHouse != null)
                {
                    dbVirtualHouse = VirtualHouse;
                }
                db.SaveChanges();
            }
        }

        public static void DeleteVirtualHouse(VirtualHouse VirtualHouse)
        {
            using (ElectionContext db = new ElectionContext())
            {
                db.VirtualHouse.Remove(VirtualHouse);
                db.SaveChanges();
            }
        }

        ////////////Голова ЦВК
        //обрати чи змiнити голiв окружних комiсiй (до початку виборiв);
        //database.Add(chief_region_officer);
        //var id = 1;
        //var virtual_house = database.First(cro => cro.chief_region_officer_id == id);
        public static void AddChiefRegionOfficer(Election election, VirtualRegion virtualRegion, Citizen citizen)
        {
            using (ElectionContext db = new ElectionContext())
            {
                var chiefRegionOfficer = new ChiefRegionOfficer
                {
                    ElectionId = election.ElectionId,
                    VirtulRegionId = virtualRegion.VirtualRegionId,
                    CitizenId = citizen.CitizenId
                };
                db.ChiefRegionOfficer.Add(chiefRegionOfficer);
                db.SaveChanges();
            }
        }

        public static void UpdateChiefRegionOfficer(int chiefRegionOfficerId, Citizen citizen)
        {
            using (ElectionContext db = new ElectionContext())
            {
                var dbChiefRegionOfficer = db.ChiefRegionOfficer.Where(e => e.ChiefRegionOfficerId == chiefRegionOfficerId).First();
                if (dbChiefRegionOfficer != null)
                {
                    dbChiefRegionOfficer.CitizenId = citizen.CitizenId;
                }
                db.SaveChanges();
            }
        }


        //оголосити остаточнi результати виборiв у краЁнi (пiсля виборiв);
        //SELECT candidate_id, first_name, last_name, patronymic, trunc( 100.0 * COUNT(*)/ COUNT(*) over(), 2) as percent_votes  FROM vote
        //    INNER JOIN candidate ON vote.candidate_id = candidate.candidate_id
        //    INNER JOIN citizen ON candidate.citizen_id = citizen.citizen_id
        //    WHERE vote.election_id = id
        //    GROUP BY candidate_id;
        public class Result
        {
            public int CandidateId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Patronymic { get; set; }
            public int Votes { get; set; }
            public decimal VotesPercent { get; set; }
        }

        public static List<Result> GetResults(Election election)
        {
            var candidateResult = new List<Result>();

            using (ElectionContext db = new ElectionContext())
            {
                var results = from vote in db.Vote
                              join candidate in db.Candidate on vote.CandidateId equals candidate.CandidateId
                              join citizen in db.Citizen on candidate.CitizenId equals citizen.CitizenId
                              where vote.ElectionId == election.ElectionId
                              select new Result
                              {
                                  CandidateId = candidate.CandidateId,
                                  FirstName = citizen.FirstName,
                                  LastName = citizen.LastName,
                                  Patronymic = citizen.Patronymic,
                                  Votes = 0,
                                  VotesPercent = 0
                              };

                var allVotes = results.Count();

                var resultsGroupBy = results.GroupBy(e => e.CandidateId);

                foreach (var group in resultsGroupBy)
                {
                    var candidate = group.First();
                    candidateResult.Add(new Result
                    {
                        CandidateId = candidate.CandidateId,
                        FirstName = candidate.FirstName,
                        LastName = candidate.LastName,
                        Patronymic = candidate.Patronymic,
                        Votes = group.Count(),
                        VotesPercent = group.Count() / allVotes
                    });
                }

                return candidateResult;

            }
        }

        //переглянути перелiк виборцiв вiртуальних дiльниць та округiв(у будь - який час);
        public static List<Citizen> GetVirtualHouseVoters(VirtualHouse virtualHouse)
        {
            var virtualHouseVoters = new List<Citizen>();

            using (ElectionContext db = new ElectionContext())
            {
                virtualHouseVoters = (from house in db.CitizenVirtualHouse
                                      join citizen in db.Citizen on house.CitizenId equals citizen.CitizenId
                                      where house.VirtualHouseId == virtualHouse.VirtualHouseId
                                      select citizen).ToList();
            }
            return virtualHouseVoters;
        }

        public static List<Citizen> GetVirtualRegionVoters(VirtualRegion virtualRegion)
        {
            var virtualHouseVoters = new List<Citizen>();

            using (ElectionContext db = new ElectionContext())
            {
                virtualHouseVoters = (from region in db.VirtualRegion
                                      join house in db.VirtualHouse on region.VirtualRegionId equals house.VirtualRegionId
                                      join citizenHouse in db.CitizenVirtualHouse on house.VirtualHouseId equals citizenHouse.VirtualHouseId
                                      join citizen in db.Citizen on citizenHouse.CitizenId equals citizen.CitizenId
                                      where region.VirtualRegionId == virtualRegion.VirtualRegionId
                                      select citizen).ToList();
            }
            return virtualHouseVoters;
        }

        //переглянути усi скарги спостерiгачiв та звернення громадян(у будь - який час);
        //SELECT * FROM citizen_feedback;
        //SELECT * FROM observer_feedback;

        public static List<CitizenFeedback> GetCitizenFeedback(Election election)
        {
            var citizenFeedback = new List<CitizenFeedback>();

            using (ElectionContext db = new ElectionContext())
            {
                citizenFeedback = db.CitizenFeedback.Where(e => e.ElectionId == election.ElectionId).ToList();
            }
            return citizenFeedback;
        }

        public static List<ObserverFeedback> GetObserverFeedback(Election election)
        {
            var observerFeedback = new List<ObserverFeedback>();

            using (ElectionContext db = new ElectionContext())
            {
                observerFeedback = db.ObserverFeedback.Where(e => e.ElectionId == election.ElectionId).ToList();
            }
            return observerFeedback;
        }
        //////////////Голова окружної комісії

        //обрати чи змiнити голiв дiльничних комiсiй (до початку виборiв);
        //INSERT INTO chief_house_officer(election_id, virtual_house_id, citizen_id)
        //    VALUES(,,);
        //UPDATE chief_house_officer
        //SET citizen_id = id
        //WHERE chief_house_officer=1;

        public static void AddChiefHouseOfficer(Election election, VirtualHouse VirtualHouse, Citizen citizen)
        {
            using (ElectionContext db = new ElectionContext())
            {
                var ChiefHouseOfficer = new ChiefHouseOfficer
                {
                    ElectionId = election.ElectionId,
                    VirtualHouseId = VirtualHouse.VirtualHouseId,
                    CitizenId = citizen.CitizenId
                };
                db.ChiefHouseOfficer.Add(ChiefHouseOfficer);
                db.SaveChanges();
            }
        }

        public static void UpdateChiefHouseOfficer(int ChiefHouseOfficerId, Citizen citizen)
        {
            using (ElectionContext db = new ElectionContext())
            {
                var dbChiefHouseOfficer = db.ChiefHouseOfficer.Where(e => e.ChiefHouseOfficerId == ChiefHouseOfficerId).First();
                if (dbChiefHouseOfficer != null)
                {
                    dbChiefHouseOfficer.CitizenId = citizen.CitizenId;
                }
                db.SaveChanges();
            }
        }

        //надати головi ЦВК остаточнi результати виборiв в окрузi (пiсля виборiв);
        //SELECT candidate_id, first_name, last_name, patronymic, trunc( 100.0 * COUNT(*)/ COUNT(*) over(), 2) as percent_votes FROM virtual_region
        //    INNER JOIN virtual_house ON virtual_region.virtual_region_id = virtual_house.virtual_region_id
        //    INNER JOIN vote ON virtual_house.virtual_house_id = vote.virtual_house_id
        //    INNER JOIN candidate ON vote.candidate_id = candidate.candidate_id
        //    INNER JOIN citizen ON candidate.citizen_id = citizen.citizen_id
        //    WHERE vote.election_id = id AND virtual_region.virtual_region_id = virtual_id
        //    GROUP BY candidate_id;

        public static List<Result> GetResultsVirtualRegion(Election election, VirtualRegion virtualRegion)
        {
            var candidateResult = new List<Result>();

            using (ElectionContext db = new ElectionContext())
            {

                var results = from region in db.VirtualRegion
                              join house in db.VirtualHouse on region.VirtualRegionId equals house.VirtualRegionId
                              join vote in db.Vote on house.VirtualHouseId equals vote.VirtualHouseId
                              join candidate in db.Candidate on vote.CandidateId equals candidate.CandidateId
                              join citizen in db.Citizen on candidate.CitizenId equals citizen.CitizenId
                              where vote.ElectionId == election.ElectionId && region.VirtualRegionId == virtualRegion.VirtualRegionId
                              select new Result
                              {
                                  CandidateId = candidate.CandidateId,
                                  FirstName = citizen.FirstName,
                                  LastName = citizen.LastName,
                                  Patronymic = citizen.Patronymic,
                                  Votes = 0,
                                  VotesPercent = 0
                              };

                var allVotes = results.Count();
                var resultsGroupBy = results.GroupBy(e => e.CandidateId);

                foreach (var group in resultsGroupBy)
                {
                    var candidate = group.First();
                    candidateResult.Add(new Result
                    {
                        CandidateId = candidate.CandidateId,
                        FirstName = candidate.FirstName,
                        LastName = candidate.LastName,
                        Patronymic = candidate.Patronymic,
                        Votes = group.Count(),
                        VotesPercent = group.Count() / allVotes
                    });
                }

                return candidateResult;

            }
        }

        //переглянути перелiк виборцiв вiртуальних дiльниць округу (у будь - який час);
        public static List<Tuple<VirtualHouse, List<Citizen>>> GetVirtualHousesAndCitizens(VirtualRegion virtualRegion)
        {
            var virtualHouseAndCitizens = new List<Tuple<VirtualHouse, List<Citizen>>>();

            using (ElectionContext db = new ElectionContext())
            {

                var results = from house in db.VirtualHouse
                              join citizenHouse in db.CitizenVirtualHouse on house.VirtualHouseId equals citizenHouse.VirtualHouseId
                              join citizen in db.Citizen on citizenHouse.CitizenId equals citizen.CitizenId
                              where house.VirtualRegionId == virtualRegion.VirtualRegionId
                              select new
                              {
                                  virtualHouse = house,
                                  houseCitizen = citizen
                              };

                var resultsGroupBy = results.GroupBy(e => e.virtualHouse.VirtualHouseId);


                foreach (var group in resultsGroupBy)
                {
                    virtualHouseAndCitizens.Add(Tuple.Create(group.First().virtualHouse, new List<Citizen>()));

                    foreach (var element in group)
                    {
                        virtualHouseAndCitizens[virtualHouseAndCitizens.Count - 1].Item2.Add(element.houseCitizen);
                    }

                }

                return virtualHouseAndCitizens;

            }
        }

        //переглянути скарги спостерiгачiв та звернення вiртуального округу (у будь-який час);
        //SELECT * FROM citizen_feedback
        //  INNER JOIN virtual_house ON citizen_feedback.virtual_house_id = virtual_house.virtual_house_id
        //WHERE virtual_house.virtual_region_id = id;
        //SELECT * FROM observer_feedback
        //  INNER JOIN virtual_house ON observer_feedback.virtual_house_id = virtual_house.virtual_house_id
        //WHERE virtual_house.virtual_region_id = id;

        //////////Голова дільничної комісії
        //виборці віртуальної дільниці
        //---------------------//

        //долучити громадянина (без визначеноЁ дiльницi) до сво№Ё вiртуальноЁ дiльницi (до початку виборiв);
        //---------------------//

        //вилучити громадянина зi своєї вiртуальної дiльницi (до початку виборiв);
        //---------------------//


        //переглянути звернення громадян (у будь-який час);
        //SELECT * FROM citizen_feedback
        //WHERE virtual_house_id = id AND election_id = e_id;    

        //надати головi окружноЁ комiсiЁ остаточнi результати виборiв у дiльницi;
        //  SELECT candidate_id, first_name, last_name, patronymic, trunc( 100.0 * COUNT(*)/ COUNT(*) over(), 2) as percent_votes FROM virtual_house
        //    INNER JOIN vote ON virtual_house.virtual_house_id = vote.virtual_house_id
        //    INNER JOIN candidate ON vote.candidate_id = candidate.candidate_id
        //    INNER JOIN citizen ON candidate.citizen_id = citizen.citizen_id
        //  WHERE vote.election_id = id AND virtual_house.virtual_house_id = virtual_id
        //  GROUP BY candidate_id;

        //////////Спостерiгач:
        //переглянути перелiк виборцiв вiртуальноЁ дiльницi(у будь - який час);
        //---------------------//

        //переглянути звернення громадян(у будь - який час);
        //SELECT * FROM citizen_feedback
        //WHERE virtual_house_id = id AND election_id = e_id;  

        //подати скаргу (пiд час виборiв);
        //INSERT INTO observer_feedback(election_id, virtual_house_id, observer_id, text)
        //    VALUES(,,);

        ////////Громадянин:

        //подати звернення до голови вiртуальноЁ дiльницi (у будь - який час);
        //INSERT INTO citizen_feedback(election_id, virtual_house_id, citizen_id, text)
        //    VALUES(,,)
        //проголосувати(пiд час виборiв, тiльки один раз);
        //IF(EXISTS(SELECT vote_id FROM vote WHERE citizen_id = c_id AND election_id = e_id), , )
        //INSERT INTO vote(election_id, virtual_house_id, citizen_id, candidate_id)
        //    VALUES(,,);
        //переглянути результати голосування(пiсля виборiв та оголошення головою ЦВК);
        //SELECT * FROM RESULTS;








        ////////----------------------------------------------//////////Параметри виборів
        //переглянути результати голосування у країнi; ЗАГАЛЬНІ РЕЗУЛЬТАТИ?
        //SELECT candidate_id, first_name, last_name, patronymic, trunc( 100.0 * COUNT(*)/ COUNT(*) over(), 2) as percent_votes  FROM vote
        //    INNER JOIN candidate ON vote.candidate_id = candidate.candidate_id
        //    INNER JOIN citizen ON candidate.citizen_id = citizen.citizen_id
        //    WHERE vote.election_id = id
        //    GROUP BY candidate_id;

        //переглянути результати голосування у обраному окрузi O;
        //SELECT candidate_id, first_name, last_name, patronymic, trunc( 100.0 * COUNT(*)/ COUNT(*) over(), 2) as percent_votes FROM virtual_house 
        //    INNER JOIN vote ON virtual_house.virtual_house_id = vote.virtual_house_id
        //    INNER JOIN candidate ON vote.candidate_id = candidate.candidate_id
        //    INNER JOIN citizen ON candidate.citizen_id = citizen.citizen_id
        //    WHERE vote.election_id = id AND virtual_region.virtual_region_id = virtual_id
        //    GROUP BY candidate_id;

        //переглянути результати голосування у обранiй дiльницi D;
        //  SELECT candidate_id, first_name, last_name, patronymic, trunc( 100.0 * COUNT(*)/ COUNT(*) over(), 2) as percent_votes FROM virtual_house
        //    INNER JOIN vote ON virtual_house.virtual_house_id = vote.virtual_house_id
        //    INNER JOIN candidate ON vote.candidate_id = candidate.candidate_id
        //    INNER JOIN citizen ON candidate.citizen_id = citizen.citizen_id
        //  WHERE vote.election_id = id AND virtual_house.virtual_house_id = virtual_id
        //  GROUP BY candidate_id;

        //показати усi округи та для кожного з них: кiлькiсть виборцiв, що проголосували, переможця у окрузi та його результат;
        //  WITH region_candidate AS(
        //  SELECT * FROM virtual_region
        //    INNER JOIN virtual_house ON virtual_region.virtual_region_id = virtual_house.virtual_region_id
        //    INNER JOIN vote ON virtual_house.virtual_house_id = vote.virtual_house_id
        //    INNER JOIN candidate ON vote.candidate_id = candidate.candidate_id
        //    INNER JOIN citizen ON candidate.citizen_id = citizen.citizen_id
        //  WHERE vote.election_id = id
        //), region_votes AS(
        //SELECT virtual_region_id, virtual_region.name, COUNT(*) as votes FROM region_candidate GROUP BY virtual_region_id
        //), region_candidate_votes AS(
        //SELECT virtual_region_id, candidate_id, first_name, last_name, patronymic, COUNT(*) as candidate_votes FROM region_candidate GROUP BY virtual_region_id, candidate_id
        //),
        //  SELECT region_voters.virtual_region_id, region_votes.name, candidate_id, first_name, last_name, patronymic, MAX(candidate_votes) FROM region_voters
        //    INNER JOIN region_candidate_votes ON region_voters.virtual_region_id = region_candidate_votes.virtual_region_id;
        //  GROUP BY region_voters.virtual_region_id;


        //показати усi дiльницi обраного округу O та для кожноЁ з них: 
        //кiлькiсть виборцiв, що про - голосували, переможця у дiльницi та його результат;
        //  WITH region_candidate AS(
        //  SELECT * FROM virtual_region
        //    INNER JOIN virtual_house ON virtual_region.virtual_region_id = virtual_house.virtual_region_id
        //    INNER JOIN vote ON virtual_house.virtual_house_id = vote.virtual_house_id
        //    INNER JOIN candidate ON vote.candidate_id = candidate.candidate_id
        //    INNER JOIN citizen ON candidate.citizen_id = citizen.citizen_id
        //  WHERE vote.election_id = id AND virtual_region.virtual_region_id = id
        //), 
        //.....

        //знайти кандидатiв, якi отримали принаймнi P вiдсоткiв голосiв;
        //SELECT first_name, last_name, patronymic, trunc( 100.0 * COUNT(*)/ COUNT(*) over(), 2) as percent_votes  FROM vote
        //    INNER JOIN candidate ON vote.candidate_id = candidate.candidate_id
        //    INNER JOIN citizen ON candidate.citizen_id = citizen.citizen_id
        //    WHERE vote.election_id = id AND percent_votes >= P
        //    GROUP BY candidate_id;

        //знайти кандидатiв, якi перемогли у хоча б N вiртуальних округах;

        //знайти кандидатiв, якi отримати хоча б P вiдсоткiв голосiв у принаймнi N вiртуальних округах;

        //знайти кандидатiв, якi посiли одне з перших M мiсць у принаймнi N вiртуальних дiльницях;

        //Також голова ЦВК може:
        //переглянути усiх громадян, що не були доданi до жодноЁ вiртуальноЁ дiльницi;
        //--------------------------//

        //переглянути усiх громадян, що проголосували та змiнили свою вiртуальну дiльницю хоча б N разiв;

        //переглянути усiх громадян, що подали хоча б N звернень та проголосували за кандидата,
        //що перемiг у їхньому вiртуальному окрузi;

        //знайти усi дiльницi, де щодо кандидата, що перемiг, було складено хоча б N скарг;

        //переглянути усi округи у порядку спадання чи зростання вiдношення загальноЁ кiлькостi
        //скарг до загальноЁ кiлькостi голосiв;

        //переглянути усiх спостерiгачiв, що сформували хоча б N скарг;

        //переглянути усiх кандидатiв, що перемогли у хоча б N округах,
        //спостерiгачi яких склали хоча б M скарг;




    }
}
