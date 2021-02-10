using AutoMapper;
using AutoMapper.Configuration;
using DbFile.Model;
using DbFile.Model.QuestionnaireStuff;
using MazeCore;
using MazeCore.CellStuff;
using Questionnaire.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeG1
{
    public class MapperBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Mapper GetMapper()
        {
            var configurationExpression = new MapperConfigurationExpression();

            configurationExpression.CreateMap<Human, DbHuman>();
            configurationExpression.CreateMap<DbHuman, Human>();

            configurationExpression.CreateMap<BaseCell, DbCell>()
                .ForMember(nameof(DbCell.X), opt => opt.MapFrom(cell => cell.X))
                .ForMember(nameof(DbCell.Y), opt => opt.MapFrom(cell => cell.Y))
                .ForMember(nameof(DbCell.CellType),
                   opt => opt.MapFrom(cell => CalcType(cell)));

            configurationExpression.CreateMap<DbCell, BaseCell>()
                .ConvertUsing(dbCell => GenerateCell(dbCell));

            configurationExpression.CreateMap<QuestionnaireMain, DbBaseModelQuestionnaire>();
            configurationExpression.CreateMap<DbQuestionnaire, QuestionnaireMain>();

            var config = new MapperConfiguration(configurationExpression);
            var mapper = new Mapper(config);
            return mapper;
        }

        private CellType CalcType(BaseCell cell)
        {
            if (cell is Wall)
            {
                return CellType.Wall;
            }
            if (cell is Coin)
            {
                return CellType.Coin;
            }
            if (cell is Ground)
            {
                return CellType.Ground;
            }
            if (cell is Well)
            {
                return CellType.Well;
            }

            throw new Exception("Не известный тип ячейки");
        }

        private BaseCell GenerateCell(DbCell dbCell)
        {
            var x = dbCell.X;
            var y = dbCell.Y;
            switch (dbCell.CellType)
            {
                case CellType.Ground:
                    return new Ground(x, y, null);
                case CellType.Wall:
                    return new Wall(x, y, null);
                case CellType.Coin:
                    return new Coin(x, y, null);
                case CellType.Well:
                    return new Well(x, y, null);
                default:
                    throw new Exception($"Забыл рассказать как создавать ячейки типа {dbCell.CellType}");
            }
        }
    }
}
