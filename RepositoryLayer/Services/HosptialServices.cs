﻿using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.JwtToken;

namespace RepositoryLayer.Services
{
    public class HosptialServices : IHospitalServices
    {
        public readonly HospitalManagmentContext hospitalManagmentContext;
        public IConfiguration configuration;
        public HosptialServices(HospitalManagmentContext hospitalManagmentContext, IConfiguration configuration)
        {
            this.hospitalManagmentContext = hospitalManagmentContext;
            this.configuration = configuration;
        }

        public DoctorEntity AddDoctors(DoctorEntity doctorEntity)
        {
            try
            {
                DoctorEntity doctor = hospitalManagmentContext.Doctors.Where(x => x.DoctorName == doctorEntity.DoctorName).FirstOrDefault();

                if (doctor == null)
                {
                    DoctorEntity doc = new DoctorEntity
                    {
                        DoctorName = doctorEntity.DoctorName,
                        Qualification = doctorEntity.Qualification,
                        salary = doctorEntity.salary,
                        HospitalId = doctorEntity.HospitalId,
                        Email = doctorEntity.Email,
                        Password = doctorEntity.Password
                    };
                    hospitalManagmentContext.Doctors.Add(doc);
                    hospitalManagmentContext.SaveChanges();

                    return doc;
                }

                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public HospitalEntity AddHospital(HospitalEntity hospitalEntity)
        {
            try
            {
                HospitalEntity hospital = hospitalManagmentContext.Hospitals.Where(x => x.HospitalName == hospitalEntity.HospitalName && x.HospitalCity == hospitalEntity.HospitalCity).FirstOrDefault();
                if (hospital == null)
                {
                    HospitalEntity hospitalRL = new HospitalEntity
                    {
                        HospitalAddress = hospitalEntity.HospitalAddress,
                        HospitalCity = hospitalEntity.HospitalCity,
                        HospitalName = hospitalEntity.HospitalName,
                        HospitalEmail = hospitalEntity.HospitalEmail,
                        HospitalPassword = hospitalEntity.HospitalPassword,
                    };

                    hospitalManagmentContext.Hospitals.Add(hospitalRL);
                    hospitalManagmentContext.SaveChanges();

                    return hospitalRL;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveDoctor(int DoctorID)
        {
            try
            {
                DoctorEntity doctorEntity = hospitalManagmentContext.Doctors.Where(x => x.DoctorID == DoctorID).FirstOrDefault();
                if (doctorEntity != null)
                {
                    hospitalManagmentContext.Doctors.Remove(doctorEntity);
                    hospitalManagmentContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string LoginHospital(string Email, string Password)
        {
            try
            {
                HospitalEntity hospitalEntity = hospitalManagmentContext.Hospitals.Where(x => x.HospitalEmail == Email && x.HospitalPassword == Password).FirstOrDefault();

                if (hospitalEntity != null)
                {
                    Token jwtToken = new Token(this.configuration);
                    return jwtToken.GenerateToken(hospitalEntity.HospitalEmail, hospitalEntity.HospitalID, "Hospital");
                }

                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<DoctorEntity> ViewDoctors(int hospitalId)
        {
            try
            {
                IEnumerable<DoctorEntity> listOfDoctors = hospitalManagmentContext.Doctors.Where(x => x.HospitalId == hospitalId);
                if (listOfDoctors.Count() > 0)
                {
                    return listOfDoctors;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public HospitalEntity ViewHOspital(int hospitalId)
        {
            try
            {
                HospitalEntity hospitalEntity = hospitalManagmentContext.Hospitals.Where(x => x.HospitalID == hospitalId).FirstOrDefault();
                if (hospitalEntity != null)
                {
                    return hospitalEntity;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
